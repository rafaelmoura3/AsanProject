<template >
  <div>
    <div class="text-center">
      <v-snackbar
        class="snackbar"
        right
        top
        v-model="spaceShipProblem.snackbar"
        :multi-line="true"
      >
        <div class="d-flex justify-content-center h5">Novo Problema Encontrado</div>
        <div class="snackBarConfig">
          <div v-if="spaceShipProblem">
            <div>Nome da nave: {{ spaceShipProblem.name }}</div>
            <div>Vida da nave: {{ spaceShipProblem.health }}</div>
            <div>Dano causado: {{ spaceShipProblem.damage }}</div>
            <div>Problema: {{ spaceShipProblem.problemName }}</div>
          </div>
        </div>
        <template>
          <div class="d-flex justify-content-end">
            <v-btn text @click="spaceShipProblem.snackbar = false" class="btn-gold">Fechar</v-btn>
          </div>
        </template>
      </v-snackbar>
    </div>
  </div>
</template>
<script>

export default {
  props: {
    spaceShipProblem: {
      default: function () {
        return {
          name: "StarShip",
          health: 10,
          damage: 50,
          problem: "Colisão com outra nave",
          snackbar: true
        }
      }
    },

  },
  watch: {
    spaceShipProblem (val) {
      console.log("Abrindo snackbar", val)
      this.spaceShipProblem.snackbar = true
    },
  }
}
</script>

<style  lang="scss" scoped>
@import "../assets/scss/index.scss";
.snackbar {
  margin-top: 100px;
}
html,
body {
  overflow: hidden;
}
</style>
