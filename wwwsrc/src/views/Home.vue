<template>
  <div class="home">
    <h1 class="text">Welcome Home Friend</h1>
    <div
      class="text-color"
      v-for="publickeep in publicKeeps"
      :key="publickeep.id"
    >
      {{ publickeep.name }}
      <button @click="deleteKeepz(publickeep.id)">Delete</button>
      {{ publickeep.id }}
    </div>
    <h3>Hey Look Its Create Time</h3>
    <div>
      <form @submit.prevent="makeKeep">
        <input type="text" v-model="newKeep.name" placeholder="Name" />
        <input type="text" v-model="newKeep.img" placeholder="Image Url" />
        // <input type="text" v-model="newKeep.private" placeholder="Private" />
        <input
          type="text"
          v-model="newKeep.description"
          placeholder="Description"
        />
        <button>Make Keep</button>
      </form>
    </div>
  </div>
</template>
<script>
//  <input type="text" v-model="newKeep." placeholder="" />

export default {
  name: "home",
  data() {
    return {
      newKeep: {
        name: "",
        img: "",
        description: ""
        // private: ""
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
      this.newKeep = {
        name: "",
        img: "",
        description: ""
        // private: ""
      };
    }
  }
};
</script>

<style>
.text {
  text-align: Center;
  color: green;
}
</style>
