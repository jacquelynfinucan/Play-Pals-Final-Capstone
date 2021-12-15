<template>
  <div class="home-news">
    <!-- <img id="img-dogs" src="@/assets/Dog_Images/8.jpg" alt="dogs-fetching-stick" /> -->
    <div id="text">
    <h3 id="reviews-title">Play Pals Reviews:</h3>
    <ul id="reviews-list">
      <li>
          <p>"Congratulations on Play Pals grand launch! Gracie and I were so excited to be your first user/pet! We can't wait to meet
            so many new pupper friends and have fun playdates!" ~Debbie from Parma
          </p>
      </li>
      <li>
          <p>
            "We love Play Pals! This site is so easy to use and we've had so many great meetups with other dog owners in our neighborhood." ~Jim from Lakewood
          </p>
      </li>
      <li>
          <p>
            "Vida and Flopsy both had a ball at our playdate with Mr. Bubbles last week! They ran around the park so many times they were so exhausted  
            when we got home that they let me brush them with no fight! Play Pals has been so good for our doggos and helps us get their exercise in. 
            We especially love our playdates at 'The Happy Dog Playground' when it's raining or too cold out-they have so many fun toys." ~Jennifer from Cleveland
          </p>
        </li>
        <li>
          <p>
            "Gumby says woof woof for Play Pals!" ~Daniel from Shaker Heights
          </p>
        </li>
    </ul>
    <!-- <br>
    <h2>About Play Pals:</h2>
    <p>Hello and welcome to Play Pals! We're so glad you've chosen us for your pets' playdates. Team Tilde really loves animals and think they deserve just as
      much opportunity to make new friends as we do! Three years ago, after adopting our first pupper, Juniper, we were having a hard time finding other
      dog owners who wanted to meet up and let our dogs play together. We knew social interaction was important, as well as play time and exercise, so we
      tried to get Juniper outside as much as we could, but there's only so many hours we could throw a frisbee over and over. So we started reaching out
      to friends or folks who went to the same vet or groomers as us to start making a network of dog parents who wanted to get together for "playdates"
      and thus Play Pals was born. We've grown from just a text chain with five people, to now an online portal for pet owners all over Northeast Ohio
      to find each other and set up playdates for their puppers! We hope you and your dog enjoy making new friends and we'd love to hear about all your 
      fun adventures! 
    </p> -->
  </div>
  </div>
</template>

<script>
export default {
  name: "home-news"
};
</script>

<style scoped>
.home-news {
    border-radius: 5px;
    border: solid 1px darkgrey;
    padding: 5px;
}

#reviews-title{
  margin-top: 5px;
  margin-bottom: 5px;
}

#reviews-list{
  font-style: italic;
  font-size: small;
}

#img-dogs{
  max-height: 350px;
  border-radius: 5px;
  justify-content: center;
  /* position: relative; */
   /* z-index:0; */
}

#text{
  /* position: absolute; */
  /* z-index:1; */
  /* opacity: 0.8;
  background-color: var(--secondary-color); */
}
</style>