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
      <button>Views:{{ publickeep.Views }}</button>
      <button>Shares:{{ publickeep.Shares }}</button>
      <button>Keeps{{ publickeep.Keeps }}</button>
    </div>
    <h3>Hey Look Its Create Time</h3>
    <div>
      <form @submit.prevent="makeKeep">
        <input type="text" v-model="newKeep.name" placeholder="Name" />
        <input type="text" v-model="newKeep.img" placeholder="Image Url" />

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
        <button>Make Keep</button>
      </form>
    </div>
  </div>
</template>
<script>
//  <input type="text" v-model="newKeep." placeholder="" />
// <div class="btn-group" data-toggle="buttons">
//           <label class="btn btn-primary active"

export default {
  name: "home",
  data() {
    return {
      newKeep: {
        name: "",
        img: "",
        description: "",
        IsPrivate: Boolean
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
        description: "",
        IsPrivate: Boolean
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
