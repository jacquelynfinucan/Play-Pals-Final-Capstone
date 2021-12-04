<template>
  <div class="home-welcome">    
    <div class="welcome-title">
        <h1>Pet Pals</h1>
    </div>
    <div class="welcome-image">
        <img id="img-dogs" src="@/assets/dogs.png" alt="dogs-playing" />
    </div>
    <div class="welcome-content">       
        <h2>Welcome to Pet Pals!</h2>
        <div>
        <h3>Pet Pals offers you the abilty to:</h3> 
        <ul>
            <li> Register your pets for play dates</li>
            <li> Request play dates with other users pets</li>
            <li> Accept play date requests from other users </li>
        </ul>
        </div>
        <h3>New users register <router-link class="nav-link" v-bind:to="{name: 'register'}">HERE</router-link> to get started on your new pet adventures!</h3>
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
  grid-template-columns: 1fr 1fr;
  grid-template-areas:
    "title title"
    "image content";
}

.welcome-title {
    grid-area: title;
}

.welcome-image {
  grid-area: image;
}

.welcome-content {
    grid-area: content;
}

h1 {
    text-align: center;
}

#img-dogs {
    max-width: 45vw;
    border-radius: 5px;
}

@media only screen and (max-width: 480px) {
    .home-welcome {
        grid-template-columns: 1fr;
        grid-template-areas:
            "title"
            "image"
            "content";
    } 
}
</style>