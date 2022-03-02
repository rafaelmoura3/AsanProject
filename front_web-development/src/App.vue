<template>
  <div id="app" class="body-style">
    <v-app>
      <div>
        <Background />
        <Appbar />
        <v-container>
          <div id="content">
            <router-view></router-view>
          </div>
        </v-container>
      </div>
    </v-app>
  </div>
</template>
<script>
import Appbar from "./components/Appbar.vue"
import Background from "./components/Background.vue"
export default {
  components: {
    Appbar,
    Background,
  },
  data() {
    return {
      dialogOptions: {
        dialog: false,
        title: "Sucesso!",
        message: "Item Excluido Com sucesso",
        type: "success",
        botaoText: "Ok"
      }
    }
  },
  methods: {
    dialog_false() {
      this.dialogOptions.dialog = false
    },
    openDialog() {
      this.dialogOptions.dialog = true
    }
  }
}
</script>
<style >
#content {
  position: relative;
  z-index: 6 !important;
}
</style>
