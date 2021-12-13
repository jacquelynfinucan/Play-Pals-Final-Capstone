using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class MessageSqlDao : IMessageDao
    {
        private readonly string connectionString;

        public MessageSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Message AddMessage(Message message)
        {
            int newMessageID = 0;
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.play_date_messages (play_date_id, from_user_id, from_pet_id, post_date, message_text) " +
                                                    "OUTPUT INSERTED.message_id " +
                                                    "VALUES(@playDateID, @fromUserID, @fromPetID, GETDATE(), @messageText);", conn);
                    cmd.Parameters.AddWithValue("@playDateID", message.PlayDateID);
                    cmd.Parameters.AddWithValue("@fromUserID", message.FromUserID);
                    cmd.Parameters.AddWithValue("@fromPetID", message.FromPetID);
                    cmd.Parameters.AddWithValue("@messageText", message.MessageText);

                    newMessageID = (int)cmd.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return GetMessage(newMessageID);
        }

        public void DeleteMessage(int messageID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("", conn);
                    cmd.Parameters.AddWithValue("@messageID", messageID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected != 1)
                    {
                        throw new Exception("Error is Message deletion for MessageID: " + messageID);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Message GetMessage(int messageID)
        {
            Message newMessage = new Message();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT message_id, play_date_id, from_user_id, U.username AS from_username, " + 
                                                    "from_pet_id, PP.pet_name AS from_pet_name, post_date, message_text " + 
                                                    "FROM dbo.play_date_messages AS PDM " +
                                                    "INNER JOIN dbo.users AS U ON U.user_id = PDM.from_user_id " +
                                                    "INNER JOIN dbo.pet_profile AS PP ON PP.pet_id = PDM.from_pet_id " +
                                                    "WHERE message_id = @messageID;", conn);
                    cmd.Parameters.AddWithValue("@messageID", messageID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        newMessage = GetMessageFromReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return newMessage;
        }

        public List<Message> GetMessagesForPlayDate(int playDateID)
        {
            List<Message> messagesForPlayDate = new List<Message>();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT message_id, play_date_id, from_user_id, U.username AS from_username, " +
                                                    "from_pet_id, PP.pet_name AS from_pet_name, post_date, message_text " +
                                                    "FROM dbo.play_date_messages AS PDM " +
                                                    "INNER JOIN dbo.users AS U ON U.user_id = PDM.from_user_id " +
                                                    "INNER JOIN dbo.pet_profile AS PP ON PP.pet_id = PDM.from_pet_id " +
                                                    "WHERE play_date_id = @playDateID " +
                                                    "ORDER BY post_date DESC;", conn);
                    cmd.Parameters.AddWithValue("@playDateID", playDateID);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Message message = GetMessageFromReader(reader);
                        messagesForPlayDate.Add(message);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return messagesForPlayDate;
        }

        public Message UpdateMessage(int messageID, Message message)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE dbo.play_date_messages SET play_date_id = @playDateID, " + 
                                                    "from_user_id = @fromUserID, from_pet_id = @fromPetID, post_date = @postDate, " + 
                                                    "message_text = @messageText WHERE message_id = @messageID;", conn);
                    cmd.Parameters.AddWithValue("@playDateID", message.PlayDateID);
                    cmd.Parameters.AddWithValue("@fromUserID", message.FromUserID);
                    cmd.Parameters.AddWithValue("@fromPetID", message.FromPetID);
                    cmd.Parameters.AddWithValue("@postDate", message.PostDate);
                    cmd.Parameters.AddWithValue("@messageText", message.MessageText);
                    cmd.Parameters.AddWithValue("@messageID", messageID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return GetMessage(message.MessageID);
        }

        private Message GetMessageFromReader(SqlDataReader reader)
        {
            Message message = new Message();

            message.MessageID = Convert.ToInt32(reader["message_id"]);
            message.PlayDateID = Convert.ToInt32(reader["play_date_id"]);
            message.FromUserID = Convert.ToInt32(reader["from_user_id"]);
            message.FromUsername = Convert.ToString(reader["from_username"]);
            message.FromPetID = Convert.ToInt32(reader["from_pet_id"]);
            message.FromPetName = Convert.ToString(reader["from_pet_name"]);
            message.PostDate = Convert.ToDateTime(reader["post_date"]);
            message.MessageText = Convert.ToString(reader["message_text"]);

            return message;
        }
    }
}
