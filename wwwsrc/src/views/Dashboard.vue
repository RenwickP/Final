<template>
  <div class="dashboard">
    <h1 class="text">WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div><input type="text" /></div>
    <h3>Check Out Your Vaults!</h3>
    <div>
      <div v-for="vault in vaults" :key="vault.id">
        <router-link :to="{ name: 'vaults', params: { id: vault.id } }">
          {{ vault.id }}
        </router-link>
        <button @click="getVk(vault.id)">getStuff</button>

        <button @click="deleteVault(vault.id)">Delete</button>
      </div>

      <form @submit.prevent="makeVault">
        <input type="text" v-model="newVault.name" placeholder="Name" />
        <input
          type="text"
          v-model="newVault.description"
          placeholder="Description"
        />
        <button>Create Vault</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      newVault: {
        name: "",
        description: ""
      }
    };
  },
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
  },
  computed: {
    publicKeeps() {
      return this.$store.state.publicKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    getVk(id) {
      this.$store.dispatch("getVaultKeepByVaultId", id);
    },
    makeVault() {
      let vault = { ...this.newVault };
      this.$store.dispatch("makeVault", vault);
      this.newVault = {
        name: "",
        description: ""
      };
    },
    deleteVault(id) {
      this.$store.dispatch("deleteVault", id);
    }
  }
};
// <router-link :to="{name: 'vaults' , params: {id: vault.id} }">

//  <form @submit.prevent="makeVault">
//     <input type="text" v-model="newVault.name" placeholder="Name" />
//     <input
//       type="text"
//       v-model="newVault.description"
//       placeholder="Description"
//     />
//     <button>Create Vault</button>
//   </form>
</script>

<style>
.text {
  text-align: Center;
  color: green;
}
</style>
