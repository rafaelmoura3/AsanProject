<template >
  <div>
    <SnackBarShipProblem :spaceShipProblem="spaceShipProblem" />
    <DialogMaintenance
      :spaceShip="spaceShip"
      :dialogOptions="dialogOptions"
      @cancelarManutencao="cancelarManutencao"
      @efetuarManutencao="efetuarManutencao"
    />
    <Canvas @ableDialog="ableDialog" @spaceShipProblem="setSpaceShipProblem" />
  </div>
</template>
<script>
import Canvas from "../../components/Canvas.vue";
import DialogMaintenance from "../../components/DialogMaintenance.vue";
import SnackBarShipProblem from "../../components/SnackBarShipProblem.vue";
export default {
  components: {
    Canvas,
    DialogMaintenance,
    SnackBarShipProblem,
  },
  data() {
    return {
      spaceShip: {
        name: "",
        health: 0,
        year: 2000,
      },
      dialogOptions: {
        dialog: false,
      },
      spaceShipProblem: null,
    };
  },

  methods: {
    ableDialog(spaceShip) {
      this.spaceShip = spaceShip.spaceShip
      this.dialogOptions.dialog = true
      this.dialogOptions.title = "Dados da nave"
    },
    efetuarManutencao(callback) {
      this.$router.push({ path: `maintenances/repair/${callback}` })
    },
    cancelarManutencao() {
      this.dialogOptions.dialog = false
    },
    setSpaceShipProblem(spaceShipProblem) {
      this.spaceShipProblem = spaceShipProblem
      this.spaceShipProblem.snackbar = true
      
    },
  },
  watch: {
    'spaceShipProblem.snackbar': function (val) {
      console.log(val)
    },
  }
}
</script>
<style  lang="scss" scoped>
.canvas {
  border: 2px solid green;
}
.hidden {
  display: none;
}
.button-active-maintanance {
  z-index: 1;
  border: none;
  position: absolute;
  top: 20%;
  right: 50%;
}
html,
body {
  overflow: hidden;
}
// .pontilhada {
//     right: 2vw;
//     bottom: 1vh;
//     height: 20vh;
//     border-width: 5px;
//     border-style: dashed;
//     border-color: #f00;
//     margin-bottom: 15vh;
// }
// .text-maintenance {
//     font-size: 1.5rem;
//     opacity: 0.5;
// }
</style>
