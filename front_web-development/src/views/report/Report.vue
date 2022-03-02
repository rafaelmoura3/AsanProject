<template>
  <div>
    <div class="d-flex justify-center titulo">Relatório</div>
    <v-card elevation="5" class="p-4 mb-4">
      <!-- v-for="report in reports"
      :key="report" -->
      <div class="d-flex justify-center">
        A Nave 1, com vida de 10%, recebeu manutenção e está 50% recuperada.
      </div>
    </v-card>
    <v-card elevation="5" class="p-4 mb-4">
      <div class="d-flex justify-center">
        A Nave 2, com vida de 7%, recebeu manutenção e está 71% recuperada.
      </div>
    </v-card>
    <v-card elevation="5" class="p-4 mb-4">
      <div class="d-flex justify-center">
        A Nave 3, com vida de 30%, recebeu manutenção e está 82% recuperada.
      </div>
    </v-card>
    <v-card elevation="5" class="p-4 mb-4">
      <div class="d-flex justify-center">
        A Nave 4, com vida de 40%, recebeu manutenção e está 100% recuperada.
      </div>
      <!-- <div class="d-flex justify-center">
        A {{ reports.nameShip }}, com vida de {{ reports.lifeShip }}%, recebeu
        manutenção e está {{ reports.lifeShipRepair }}% recuperada.
      </div> -->
    </v-card>
  </div>
</template>
<script>
export default {
  data() {
    return {
      // reports: {
      //     id: null,
      //     nameShip: "",
      //     lifeShip: null,
      //     lifeShipRepair: null
      // },
      // datas: []
    };
  },

  created() {
    // this.dataFalse();
  },

  methods: {
    dataFalse() {
      // for (let i = 0; i <= 4; i++) {
      //     this.reports.nameShip = "Nave " + i;
      //     this.reports.lifeShip = Math.ceil(Math.random()*10);
      //     this.reports.lifeShipRepair = this.reports.lifeShip + Math.ceil(Math.random()*10);
      //     this.datas[i] = this.reports;
      //     console.log(this.datas);
      // }
    },
  },
};
</script>
<style lang="scss">
@import "../../../src/assets/scss/index.scss";
</style>