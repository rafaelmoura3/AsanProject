<template >
  <div>
    <v-app-bar class="App-bar-bg" dense dark>
      <v-app-bar-nav-icon @click="drawer = true"></v-app-bar-nav-icon>

      <v-toolbar-title>Menu</v-toolbar-title>

      <v-spacer></v-spacer>

      <div class="logo-asan">
        <v-avatar>
          <img src="../../public/asan2.png" />
        </v-avatar>
      </div>

      <v-menu left bottom>
        <template>
          <v-btn icon>
            <v-icon>mdi-dots-vertical</v-icon>
          </v-btn>
        </template>

        <v-list>
          <v-list-item>
            <v-list-item-title>Option</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>

    <v-navigation-drawer v-model="drawer" absolute temporary>
      <div v-for="(link, index) in links" :key="index">
        <router-link class="remove-underline" :to="{ name: link.nameRoute }" active-class="link-ativo">
          <v-list dense>
            <v-list-item class="bg-hover">

              <v-list-item-content>
                <div class="d-flex justify-left">
                  
                  <div class="remove-underline">
                    
                  <font-awesome-icon :icon=" link.icone " class="mr-4"/>
                    {{ link.title }}
                  </div>
                </div>
              </v-list-item-content>
            </v-list-item> 
          </v-list>
        </router-link>
      </div>
    </v-navigation-drawer>
  </div>
</template>
<script>

export default {
    
  data() {
    return {
      drawer: false,

      links: [
        {
          title: "Naves",
          icone: "fa-solid fa-shuttle-space",
          nameRoute: "shipsList",
        },
        {
          title: "Tipo de Naves",
          icone: "fa-solid fa-circle-plus",
          nameRoute: "spaceshiptypeList",
        },
        {
          title: "Ferramentas",
          icone: "fa-solid fa-screwdriver-wrench",
          nameRoute: "toolsList",
        },
        {
          title: "Peças",
          icone: "fa-solid fa-microchip",
          nameRoute: "partsList",
        },
        {
          title: 'Gerenciamento',
          icone: "fa-solid fa-gear",
          nameRoute: 'management',
        },
        {
          title: "Eficiência das Ferramentas",
          icone: "fa-solid fa-percent",
          nameRoute: "toolPerPartList",
        },
        {
          title: "Problemas",
          icone: "fa-solid fa-circle-exclamation",
          nameRoute: "problemsList",
        },
        // {
        //   title: "Relatório",
        //   icone: "fa-solid fa-rectangle-list",
        //   nameRoute: "report",
        // },
      ],
    };
  },
};
</script>
<style  lang="scss">
.App-bar-bg {
  background: rgba(255, 255, 255, 0.1);
}
.title-menu {
  font-size: 1.5rem;
  text-decoration: none !important;
  border: none !important;
  display: inline-block;
}
.title-menu::after {
  display: none !important;
}

.icons-menu {
  padding-left: 10px;
  width: 30px;
  height: 30px;
}
.bg-hover:hover {
  background-color: #2c2929;
}
</style>
