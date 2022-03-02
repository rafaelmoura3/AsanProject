<template >
  <div>
    <DialogMessage
      :dialogOptions="dialogOptions"
      @dialog_false="callback_dialog"
    />
    <div class="d-flex justify-center titulo">Manutenção da nave</div>

    <div class="d-flex justify-center">
      <img :src="image" width="200" height="100" />
    </div>

    
      <div class="mt-10 d-flex justify-center">
      
        <v-progress-linear
          class="rounded w-25"
          color="light-green darken-4"
          
          height="10"
          :value="shipsData.health"
          
        ></v-progress-linear>
      </div>
    

    <!-- <v-container fluid>
        <v-row align="center">
          <v-col
            class="d-flex"
            cols="12"
            sm="6"
          >
            <v-select
              :items="getParts"
              item-text="name"
              item-value="id"
              label="Peça"
            ></v-select>
          </v-col>

          <v-col
            class="d-flex"
            cols="12"
            sm="4"
          >
            <v-select 
              :items="getTools"
              item-text="name"
              item-value="id"
              label="Ferramenta"
            ></v-select>
          </v-col>

          <v-col
            class="d-flex"
            cols="12"
            sm="2"
          >
            <v-text-field
              :disabled="inputDisable"
              v-model="efficiency"
              label="Eficiencia"
            ></v-text-field>
          </v-col>

          
        </v-row>
      </v-container>
     -->

    <center class="d-flex justify-content-around">
      <v-btn
        primary
        class="mt-10 btn-gold"
        @click="submit()"
        :loading="salvarAlteraçõesLoading"
        >Realizar Manutenção</v-btn
      >
    </center>
  </div>
</template>
<script>
import DialogMessage from "../../components/DialogMessage.vue";
import useVuelidate from "@vuelidate/core";
import { required } from "@vuelidate/validators";
import DefaultService from "../../services/defaultService";

export default {
  async created() {
    this.defaultService = new DefaultService(this.$http, "ships");
    if (this.$route.name == "maintenance") {
      await this.getShipByID();
      
      this.relationEfficiency();
      
    }
    

    // this.getTools();
    // this.getShipByID();
    // this.setParts();

    // this.setPartsPerShip();

    var svg_health = `<svg version="1.1" id="Capa_1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" x="0px" y="0px"
	   viewBox="0 0 58 58" style="enable-background:new 0 0 58 58;" xml:space="preserve">
  <g>
	  <path style="fill:${this.shipsData.color};" d="M36.75,48v-9c0-0.552,0.448-1,1-1s1,0.448,1,1v2h12.881c-1.064-4.299-6.313-8.115-9.927-10.632
		  c-1.511-1.052-2.126-2.724-2.954-4.368c-1.561-3.099-3.197-7.479-3.769-10.914l-0.53-3.067c-0.056,0.01-0.112,0.024-0.168,0.024
		  c-0.329,0-0.651-0.162-0.842-0.459C32.384,9.942,30.833,9,29.186,9c-1.603,0-3.125,0.896-4.177,2.458
		  c-0.227,0.336-0.623,0.487-0.999,0.423l-0.554,3.205C22.883,18.521,21.311,22.901,19.75,26c-0.828,1.644-1.507,3.316-3.018,4.368
		  C13.118,32.885,7.928,36.701,6.868,41H19.75v-2c0-0.552,0.448-1,1-1s1,0.448,1,1v9c0,0.478-0.343,0.859-0.791,0.958
		  C21.017,48.984,21.08,49,21.147,49h2.009c0.191,0,0.362,0.118,0.43,0.296l0.922,2.408C24.577,51.882,24.748,52,24.939,52h4.279
		  h4.279c0.191,0,0.362-0.118,0.431-0.296l0.922-2.408C34.918,49.118,35.089,49,35.28,49h2.009c0.074,0,0.141-0.021,0.203-0.052
		  C37.068,48.832,36.75,48.461,36.75,48z"/>
	  <path style="fill:#38454F;" d="M38.75,46.008c0.009-0.001,0.017-0.007,0.026-0.008l12.493-1.004
		  c0.272-0.022,0.481-0.249,0.481-0.521V43h-13V46.008z"/>
	  <path style="fill:#38454F;" d="M6.75,43v1.475c0,0.272,0.209,0.499,0.481,0.521l12.43,1.003c0.032,0.003,0.058,0.021,0.089,0.027
		  V43H6.75z"/>
	  <path style="fill:#546A79;" d="M21.75,48v-9c0-0.552-0.448-1-1-1s-1,0.448-1,1v2H6.868c-0.042,0.17-0.09,0.339-0.118,0.511V43h13
		  v3.026c0.535,0.101,0.936,0.558,0.936,1.111v1.402c0,0.187,0.113,0.347,0.273,0.419C21.407,48.859,21.75,48.478,21.75,48z"/>
	  <path style="fill:#546A79;" d="M51.631,41H38.75v-2c0-0.552-0.448-1-1-1s-1,0.448-1,1v9c0,0.461,0.318,0.832,0.742,0.948
		  c0.151-0.076,0.258-0.228,0.258-0.409v-1.401c0-0.577,0.431-1.057,1-1.13V43h13v-1.489C51.721,41.339,51.673,41.17,51.631,41z"/>
 
	  <g>
		  <path style="fill:#E57E25;" d="M24.686,54c-0.552,0-1,0.448-1,1v1c0,0.552,0.448,1,1,1s1-0.448,1-1v-1
			  C25.686,54.448,25.238,54,24.686,54z"/>
		  <path style="fill:#E57E25;" d="M27.686,54c-0.552,0-1,0.448-1,1v2c0,0.552,0.448,1,1,1s1-0.448,1-1v-2
			  C28.686,54.448,28.238,54,27.686,54z"/>
		  <path style="fill:#E57E25;" d="M30.686,54c-0.552,0-1,0.448-1,1v2c0,0.552,0.448,1,1,1s1-0.448,1-1v-2
			  C31.686,54.448,31.238,54,30.686,54z"/>
		  <path style="fill:#E57E25;" d="M33.686,54c-0.552,0-1,0.448-1,1v1c0,0.552,0.448,1,1,1s1-0.448,1-1v-1
			  C34.686,54.448,34.238,54,33.686,54z"/>
	  </g>
	  <path style="fill:#38454F;" d="M29.186,7c1.762,0,3.423,0.724,4.748,2.031l-0.467-2.704c-0.432-2.59-1.525-3.762-3.162-5.791
		  c-0.557-0.691-1.616-0.691-2.173,0c-1.637,2.029-2.73,3.2-3.162,5.791l-0.454,2.626C25.829,7.697,27.463,7,29.186,7z"/>
	  <path style="fill:#8697CB;" d="M29.186,9c1.647,0,3.198,0.942,4.255,2.583c0.191,0.297,0.513,0.459,0.842,0.459
		  c0.056,0,0.112-0.014,0.168-0.024l-0.517-2.988C32.609,7.724,30.948,7,29.186,7c-1.723,0-3.357,0.697-4.67,1.953l-0.506,2.928
		  c0.376,0.064,0.772-0.087,0.999-0.423C26.061,9.896,27.583,9,29.186,9z"/>
	  <g>
		  <path style="fill:#546A79;" d="M33.75,40h-9c-0.552,0-1,0.448-1,1s0.448,1,1,1h9c0.552,0,1-0.448,1-1S34.302,40,33.75,40z"/>
		  <path style="fill:#546A79;" d="M33.75,35h-9c-0.552,0-1,0.448-1,1s0.448,1,1,1h9c0.552,0,1-0.448,1-1S34.302,35,33.75,35z"/>
		  <path style="fill:#546A79;" d="M24.75,32h9c0.552,0,1-0.448,1-1s-0.448-1-1-1h-9c-0.552,0-1,0.448-1,1S24.198,32,24.75,32z"/>
		  <path style="fill:#546A79;" d="M32.75,44h-7c-0.552,0-1,0.448-1,1v2c0,0.552,0.448,1,1,1s1-0.448,1-1v-1h5v1c0,0.552,0.448,1,1,1
			  s1-0.448,1-1v-2C33.75,44.448,33.302,44,32.75,44z"/>
	  </g>
 
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  <g>
  </g>
  </svg>`;
    var image = "data:image/svg+xml;base64," + btoa(svg_health);
    this.image = image;
  },
  setup() {
    return { v$: useVuelidate() };
  },
  data() {
    return {
      Parts: [],
      image: null,
      PartsPerShip: [],
      tools: [],
      ship: [],
      shipsData: {
        id: null,
        name: "",
        color: "",
        year: "",
        description: "",
        health: 1,
        statusfleetship: null,
        spaceShipTypeId: "",
      },
      method: "maintenances",
      Erros: 0,
      desserts: [],
      items: [],
      getParts: null,
      getTools: null,
      efficiency: 0,
      getShips: [],
      getPartsPerShips: [],
      inputDisable: true,
      defaultService: null,
      dialogOptions: {
        title: "",
        dialog: false,
        message: "",
        type: "darken-2",
        botaoText: "",
      },
      salvarAlteraçõesLoading: false,
      dialogLoaging: false,
    };
  },

  components: {
    DialogMessage,
  },
  validations() {
    return {
      shipsData: {
        name: { required },
        color: { required },
        year: { required },
        description: { required },
        spaceShipTypeId: { required },
      },
    };
  },
  methods: {
    callback_dialog() {
      this.dialogOptions.dialog = false;
      this.deleteLoading = false;
      this.dialogLoaging = false;
      if (this.error) {
        this.salvarAlteraçõesLoading = false;
        return;
      }
      // location.reload();
    },




    async getShipByID() {
      this.shipsData.id = this.$route.params.id;
      var spaceshipService = new DefaultService(this.$http, "ships");
      var shipByID = await spaceshipService.getById(this.shipsData.id);
      this.shipsData.name = shipByID.data.spaceShip.name;
      this.shipsData.color = shipByID.data.spaceShip.color;
      this.shipsData.year = shipByID.data.spaceShip.year;
      this.shipsData.health = shipByID.data.spaceShip.health;
      this.shipsData.description = shipByID.data.spaceShip.description;
      this.shipsData.spaceShipTypeId = shipByID.data.spaceShip.spaceShipType;
    },
    async submit() {
      const isFormCorrect = await this.v$.$validate();

      if (this.Parts.id) {
        if (!isFormCorrect) {
          return isFormCorrect;
        }
      }

      if (!isFormCorrect) {
        return isFormCorrect;
      } else {
        if (this.v$.$errors.length - this.Erros == 0) {
          //Caso houver erros do spaceshiptype
          this.salvarAlteraçõesLoading = true;
          

            var repairService = new DefaultService(
            this.$http,
            "maintenances/repair"
          );
          repairService
            .put(this.shipsData)
              .then((res) => {
                
                this.shipsData.health = res.data.spaceShip.health
                this.dialogOptions.title = "Sucesso!";
                this.dialogOptions.message = res.data.message + " Vida reparada: " + res.data.healthRepaired;
                this.dialogOptions.type = "success";
                this.dialogOptions.botaoText = "Ok";
                this.dialogOptions.dialog = true;
                this.v$.$reset();
                this.salvarAlteraçõesLoading = false;
                return res;
              })
              .catch((error) => {
                
                this.dialogOptions.title = "Falha no processamento!";
                this.dialogOptions.message = "Não foi possível realizar a manutenção!";
                this.dialogOptions.type = "error";
                this.dialogOptions.botaoText = "Tente Novamente";
                this.dialogOptions.dialog = true;
                this.error = true;
                return error;
              });
          
        }
      }
    },

    // async submit() {
    //   const isFormCorrect = await this.v$.$validate();
      
    //     if (!isFormCorrect) {
    //       return isFormCorrect;
    //     } else {
    //       //Caso houver erros do spaceshiptype
    //       this.salvarAlteraçõesLoading = true;

          // var repairService = new DefaultService(
          //   this.$http,
          //   "maintenances/repair"
          // );
          // repairService
          //   .put(this.shipsData)
    //         .then((res) => {
    //           
    //           this.dialogOptions.title = "Sucesso!";
    //           this.dialogOptions.message = "Item editado com sucesso!";
    //           this.dialogOptions.type = "success";
    //           this.dialogOptions.botaoText = "Ok";
    //           this.dialogOptions.dialog = true;
    //           this.validateToolCrud.$reset();
    //           this.salvarAlteraçõesLoading = false;
    //           return res;
    //         })
    //         .catch((error) => {
    //           
    //           this.dialogOptions.title = "Falha no processamento!";
    //           this.dialogOptions.message =
    //             "Não foi possível editar a ferramenta!";
    //           this.dialogOptions.type = "error";
    //           this.dialogOptions.botaoText = "Tente Novamente";
    //           this.dialogOptions.dialog = true;
    //           this.error = true;
    //           return error;
    //         });
    //     }
    // },

    // async getCountSpaceShipType() {
    //   this.count = await this.defaultService.getCount();
    //   let a = this.spaceShipType.id;
    //   this.test = a;
    //   for (let i = 0; i < this.count.data.length; i++) {
    //     if (a == this.count.data[i].id) {
    //       this.spaceShipTypeCount = this.count.data[i].countSpaceShip;
    //     }
    //   }
    // },

     async relationEfficiency() {
      // var efficiencyService = new DefaultService(this.$http, "toolperpart");
      var partsService = new DefaultService(this.$http, "parts");
      var toolsService = new DefaultService(this.$http, "tools");
      // var efficiencyData = await efficiencyService.getAll();
      var parts = await partsService.getAll();
      var tools = await toolsService.getAll();
      this.getParts = parts.data;
      this.getTools = tools.data;

      // if (getParts == efficiencyData.data.partId.name && getTools == efficiencyData.data.toolId.name) {
      //   this.efficiency = efficiencyData.data.efficiency;
      // }
      
    }

  }
};
</script>

<style  lang="scss" scoped>
@import "../../assets/scss/index.scss";
</style>
