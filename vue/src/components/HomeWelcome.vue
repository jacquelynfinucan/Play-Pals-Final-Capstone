<template>
  <div class="home-welcome">    
    <div class="welcome-title">
        <h1>Welcome to Play Pals!<br>
        The Pet Playdate App all your friends' dogs have been yapping about!
        </h1>
    </div>
    <div class="welcome-content container">   
        <img id="img-dogs-background" src="@/assets/Dog_Images/1.png" alt="dogs-playing"/>  
        <div class="transparent-container">
        <h2 class="list-header">Play Pals offers you the abilty to:</h2> 
        <ul>
            <li>Register your pets for playdates</li>
            <li>Browse profiles of other pets</li>
            <li>Request playdates with other pets</li>
            <li>Accept playdate requests from other users</li>
            <li>Message other users regarding scheduled playdates</li>
        </ul>
        </div>
        </div>
        <div>
    </div>     
  <div class="register-here">
  <h1>New users register <router-link class="nav-link" v-bind:to="{name: 'register'}"> HERE </router-link> to get started on your new pet adventures!</h1>
  </div>
  <div class="welcome-image">
    <img id="img-dogs1" src="@/assets/Dog_Images/14.jpg" alt="dogs-in-winter-hats" />
    <img id="img-logo" src="@/assets/Play-Pals-logos.jpeg" alt="play-pals-logo" />
    <img id="img-dogs2" src="@/assets/Dog_Images/3.jpg" alt="dog-tug-of-war" />
  </div>
  </div>
</template>

<script>
export default {
  name: "home-welcome"
};
</script>

<style scoped>
.home-welcome {
  display: grid;
  grid-template-columns: 1fr;
  grid-template-areas:
    "title"
    "content"
    "register"
    "image";
    text-align: center;
}

#img-dogs-background{
    width: 100%;
    max-height: 650px;
}

.container{
    width: auto;
    margin: auto;
    position: static;
}

.transparent-container{
    opacity: 0.8;
    position: absolute;
    top: 60%;
    right: 30%;
    background-color: var(--secondary-color);
}

.welcome-title {
    grid-area: title;
    text-align: center;
}

.register-here {
    grid-area: register;
    text-align: center;
}

.welcome-image {
  grid-area: image;
}

.welcome-content {
    grid-area: content;
}

h1, h2 {
    text-align: center;
}

#img-dogs1, #img-logo, #img-dogs2 {
    border-radius: 5px;
    max-width: 500px;
    vertical-align: middle;
    margin: 5px;
}

#img-dogs1, #img-dogs2 {
    max-height: 300px;

}

#img-logo{
    max-height: 400px;
    margin-bottom: 10px;
}

ul{
    list-style-position: inside;
    font-size: x-large;
    padding-left: 15px;
    padding-right: 15px;
}

li { 
   margin-bottom: 8px;  
}

.list-header{
    margin-top: 10px;
    margin-bottom: 0px;
}

@media only screen and (max-width: 480px) {
    .home-welcome {
        grid-template-columns: 1fr;
        grid-template-areas:
            "title"
            "content"
            "register"
            "image";
    } 
}
</style>