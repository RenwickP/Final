<template>
<div class="container-fluid bigbox">
  <div class="home">
    <h1 class="text">Welcome Home Friend</h1>
       <h5>Hey Look Its Create Time</h5>
    <div>
      <form @submit.prevent="makeKeep">
        
        <p class="smallint"> Check Box To Make Private </p>
         <input
          type="checkbox"
          v-model="newKeep.IsPrivate"
          name=""
          id=""
          checked
      
          autocomplete="off"
        />
        <input
          type="text"
          v-model="newKeep.description"
          placeholder="Description"
        />
        <input type="text" v-model="newKeep.name" placeholder="Name" />
        <input type="text" v-model="newKeep.img" placeholder="Image Url" />
      

        <button>Make Keep</button>
      <div class="spacing"></div>
      </form>
    </div>
    
    <div class="row">
    <div
      class="text-color col-4"
      v-for="publickeep in publicKeeps"
      :key="publickeep.id"
    >
      <div class="card" style="width: 18rem;">
        <img :src="publickeep.img" />
        <div class="card-body">
          <h5 {{ publickeep.name }}</h5>
          <p class="card-text">{{ publickeep.description }}</p>
          <a href="#" class="btn btn-primary">random txt</a>
        </div>
      </div>

      {{ publickeep.name }}
      <button @click="deleteKeepz(publickeep.id)">Delete</button>
      <button>Views:{{ publickeep.Views }}</button>
      <button>Shares:{{ publickeep.Shares }}</button>
      <router-link :to="{ name: 'keep', params: { id: publickeep.id } }">
        Keep
      </router-link>
    </div>
    </div>
   
 
    </div>
    </div>
  </div>

</template>
<script>
//  <input type="text" v-model="newKeep." placeholder="" />
// <div class="btn-group" data-toggle="buttons">
//           <label class="btn btn-primary active"

//  <input
//           type="checkbox"
//           v-model="newKeep.IsPrivate"
//           name=""
//           id=""
//           checked
//           autocomplete="off"
//         />


export default {
  name: "home",
  data() {
    return {
      newKeep: {
        name: "",
        img: "",
        description: "",
        IsPrivate: false
      }
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  computed: {
    user() {
      return this.$store.state.user;
    },
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    deleteKeepz(id) {
      console.log("from home", id);
      this.$store.dispatch("deleteKeep", id);
    },
    makeKeep() {
   
      let keep = { ...this.newKeep };
      this.$store.dispatch("makeKeep", keep);
       console.log("create keep running", keep)
      this.newKeep = {
        name: "",
        img: "",
        description: "",
        // IsPrivate: ""
      };
    }
  }
};
</script>

<style>
.text {
  text-align: Center;
  color: green;
},

.smallint{
  font-size: 8px;
}

.bigbox {
 

}
  
</style>
