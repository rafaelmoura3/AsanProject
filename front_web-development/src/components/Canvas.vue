<template >
    <div>
        <div class="d-flex justify-center">
            <v-stage ref="stage" :config="stageSize" __useStrictMode class="canvas" id="canvas">
                <v-layer ref="maintenacePlacement" :config="maintenacePlacement" __useStrictMode>
                    <v-image __useStrictMode :config="maintenanceConfig" />
                    <v-image __useStrictMode ref="layerPontilhado" :config="pontilhadaConfig" />
                </v-layer>
                <div v-for="(spaceShip, index) in spaceShips" :key="index">
                    <v-layer
                    @click="startMoveShip(index)"
                        @dragstart="starDragEvent($event, index)"
                        ref="layer"
                        @dragend="handleDragEnd($event, index)"
                        @dragmove="handleDragMove($event, index)"
                        :config="spaceShip.moviment"
                        __useStrictMode
                    >
                        <v-image
                            ref="shipLayer"
                            __useStrictMode
                            
                            :config="spaceShip.shipConfig"
                            @dragend="handleDragEnd($event, index)"
                        />
                        <v-text ref="textShipsName" :config="spaceShip.textShip" />
                        <v-image ref="image" :config="spaceShip.spaceshipHealthLayer" />
                    </v-layer>
                </div>
            </v-stage>
        </div>
    </div>
</template>
<script>
const width = window.innerWidth;
const height = window.innerHeight;
import DefaultService from '../services/defaultService';
//.Imagens
import setShipSvgColor from '../services/management/setShipSvgColor'
import shipHealthSvg from '../services/management/shipHealthSvg'
import imagePontilhadaMaintenance from '../assets/ships/imagePontilhadaMaintenance.png'
import imageMain from '../assets/ships/maintenance2.png'
import setShipSvgColorWithoutFlames from '../services/management/setShipSvgColorWithoutFlames'
//Imagens
//Funcoes das naves
import rotation from '../services/management/shipRotarion'
import keyboardEvents from '../services/management/keyboardEvents'
import handleDragMove from '../services/management/handleDragMove'
import stopAndStartMoveShip from '../services/management/stopAndStartMoveShip'
import shakeShipRandomly from '../services/management/shakeShipRandomly'
import starMoveShipRandomly from '../services/management/starMoveShipRandomly'
import shipBackToMove from '../services/management/shipBackToMove';
import setSpaceShipProblem from '../services/management/setSpaceShipProblem';
//.Funcoes das naves
export default {
    data() {
        return {
            spaceShipProblem: null,
            spaceShipsWithProblem: null,
            timeoutSetProblem: null,
            serviceSetProblem: null,
            textShip: true,
            timeOutMoviment: null,
            //Atributos relacionados a nave
            shipsInScreen: [],
            shipTextMovingLeft: {
                x: 40,
                y: -20,
                width: this.widthImage,
                rotation: 90,
                height: 10,
                fill: '#ddd',
                text: 'Teste'
            },
            shipTextMovingRight: {
                x: -40,
                y: 20,
                width: this.widthImage,
                rotation: -90,
                height: 10,
                fill: '#ddd',
                text: 'Teste'
            },
            shipTextMovingUp: {
                x: -15,
                y: -50,
                width: this.widthImage,
                rotation: 0,
                height: 10,
                fill: '#ddd',
                text: 'Teste'
            },
            shipTextMovingDown: {
                x: -15,
                y: -50,
                width: this.widthImage,
                rotation: 0,
                height: 10,
                fill: '#ddd',
                text: 'Teste'
            },
            widthImage: 50,//Tamanho da imagem em width
            heightImage: 75,
            animations: [],
            shipMoving: null,
            spaceShips: [],
            spaceshipsData: [],
            rotationSpeed: 10,
            idOfShipMoving: null,
            image: null,
            shipConfig: [],
            spaceshipHealthLayer: [],
            speed: 30,//Seta a velocidade
            //.Atributos relacionados a nave
            //.Relacionados a paginacao
            pagination: [5, 10, 15, 25, 50],
            actualPagination: 5,
            //.Relacionados a paginacao
            spaceshipService: null,
            //Relacionado a plataforma de manutencao
            maintenanceAbsolutePosition: null,
            maintenacePlacement: {//Aqui é onde vai ficar a manutencao
                x: 0,
                y: height / 2
            },
            image2: null,//Essa é a variável que vai receber a imagem da manutencao
            maintenanceConfig: {//Configuracao da manutencao
                width: width,
                height: height / 2,
                image: this.image2,//Aqui vai colocar a imagem da manutencao no canvas
                draggable: false,//Seta se podemos mexer na manutencao ou nao
            },
            pontilhadaConfig: {//Configuracao da manutencao
                x: 1100,
                y: 150,
                width: 650,
                height: 150,
                image: this.imagePontilhada,//Aqui vai colocar a imagem da manutencao no canvas
                draggable: false,//Seta se podemos mexer na manutencao ou nao
            },
            //.Relacionado a plataforma de manutencao
            //Relacionado aos limites e tamanho da tela
            limitRight: window.innerWidth - (window.innerWidth / 5),//Seta os Limites
            limitLeft: window.innerWidth / 20,//Seta os Limites
            limitDown: window.innerHeight - (window.innerHeight / 10),//Seta os Limites
            limitTop: (window.innerHeight / 20),//Seta os Limites
            stageSize: {//Tamanho total do canvas
                width: width,
                height: height
            },
            windowWidth: null,
            windowHeigth: null
            //.Relacionado aos limites
        };
    },
    async mounted() {
        this.spaceshipService = new DefaultService(this.$http, 'ships')
        var spaceShipThatCanReceiveProblems = await this.$http.get('/ships/verifyWitchSpaceShipCanRecieveAProblem')
        this.spaceshipsData.data = spaceShipThatCanReceiveProblems.data.shipsCanProblem
        for (let i = 0; i < 5; i++) {
            //Construindo objeto da nave
            //Seta o svg da nave com Fogo
            var svg_with_flames = this.setShipSvgColor(this.spaceshipsData.data[i].color)
            var image_with_flames = new window.Image();
            image_with_flames.src = "data:image/svg+xml;base64," + btoa(svg_with_flames);
            //Funcao que recebe cor e traz SVG pronto com cor
            //.Seta o svg da nave com fogo

            //Seta o svg da nave sem Fogo
            var svg_without_flames = this.setShipSvgColorWithoutFlames(this.spaceshipsData.data[i].color)
            //Funcao que recebe cor e traz SVG pronto com cor
            var imageWithoutFlames = new window.Image();
            imageWithoutFlames.src = "data:image/svg+xml;base64," + btoa(svg_without_flames);
            //.Seta o svg da nave com fogo

            //Svg Health//
            var svg_health = this.shipHealthSvg(this.spaceshipsData.data[i].health)
            var imageHealthPng = new window.Image();
            imageHealthPng.src = "data:image/svg+xml;base64," + btoa(svg_health);
            //Dando velocidade de trocar o fogo para apagado e acendido
            var max = 0
            var min = 0
            if (this.spaceshipsData.data[i].health == 100) {
                max = 0;
                min = 0;
            }
            else if (this.spaceshipsData.data[i].health >= 70 && this.spaceshipsData.data[i].health < 100) {
                max = 2;
                min = 1;
            }
            else if (this.spaceshipsData.data[i].health >= 40 && this.spaceshipsData.data[i].health < 70) {
                max = 2;
                min = 1;
            }
            else if (this.spaceshipsData.data[i].health >= 0 && this.spaceshipsData.data[i].health < 40) {
                max = 2;
                min = 1;
            }
            this.shipsInScreen.push(this.spaceshipsData.data[i].id)
            this.spaceShips.push({
                isShipInMaintenance: false,
                startPositionX: -this.widthImage,
                startPositionY: this.heightImage * (i + 1) + ((this.heightImage / 2) * i),
                spaceShip: this.spaceshipsData.data[i],
                moviment: {
                    draggable: true,
                    x: -this.widthImage,//Para a nave nascer fora da tela
                    y: this.heightImage * (i + 1) + ((this.heightImage / 2) * i),//Altura onde a nave respawna
                },
                shipConfig: {
                    width: this.widthImage,
                    height: this.heightImage,
                    image: image_with_flames,
                    imageWithFlames: image_with_flames,
                    imageWithoutFlames: imageWithoutFlames,
                    draggable: false,
                    angle: 0,//Angulo que a nave está virado
                    offset: {
                        x: this.widthImage / 2,//O eixo de de movimento da nave é a largura dela, dividida por 2
                        y: this.heightImage / 2,//O eixo de
                    },
                    maxRandom: max,
                    minRandom: min
                },
                spaceshipHealthLayer: {
                    y: 80,
                    width: this.widthImage,
                    height: 10,
                    image: imageHealthPng,
                    draggable: false,
                    angle: 0,
                    offset: {
                        x: this.widthImage / 2,//O eixo de de movimento da nave é a largura dela, dividida por 2
                        y: this.heightImage / 2,//O eixo de
                    },
                },
                //.Configuracao para esquerda
                // textShip: {
                //     x: 40,
                //     y: -20,
                //     width: this.widthImage,
                //     rotation: 90,
                //     height: 10,
                //     fill: '#ddd',
                //     text: 'Teste'
                // },
                //.Configuracao para esquerda
                //Configuracao para direita
                // textShip: {
                //     x: -40,
                //     y: 20,
                //     width: this.widthImage,
                //     rotation: -90,
                //     height: 10,
                //     fill: '#ddd',
                //     text: 'Teste'
                // },
                //.Configuracao para direita
                //Configuracao para cima
                // textShip: {
                //     x: -15,
                //     y: -50,
                //     width: this.widthImage,
                //     rotation: 0,
                //     height: 10,
                //     fill: '#ddd',
                //     text: 'Teste'
                // },
                //.Configuracao para cima
                //Configuracao para baixo
                textShip:
                {
                    x: -40,
                    y: 20,
                    rotation: -90,
                    height: 10,
                    fill: 'white',
                    text: this.spaceshipsData.data[i].name,
                    fontSize: '15',
                    visible: false
                },
                timeOut: null
            })

        }

        //Comandos que são executados somente depois de 1 segundo
        setTimeout(() => {
            this.maintenanceAbsolutePosition = this.$refs.layerPontilhado.getNode().absolutePosition()
            this.starMoveShipRandomly()
            this.stopAndStartMoveShip()
            this.shakeShipRandomly()
        }, 3000);

        //.Comandos que são executados somente depois de 1 segundo
    },
    async created() {
        this.windowWidth = width
        this.windowHeigth = height
        this.keyboardEvents(width, height)//Funcao chamada de outro arquivo para receber os eventos do teclado
        //Coloca a imagem da manutencao
        const image2 = new window.Image();
        image2.src = imageMain;
        image2.onload = () => {
            this.image2 = image2;
            this.maintenanceConfig.image = image2
        };
        const imagePontilhada = new window.Image();
        imagePontilhada.src = imagePontilhadaMaintenance;
        imagePontilhada.onload = () => {
            this.pontilhadaConfig.image = imagePontilhada
        };
        //Buscando problemas na nave
        this.serviceSetProblem = new DefaultService(this.$http, '/problems/random')
        setInterval(() => {
            this.setSpaceShipProblem()
        }, 15000);
        //.Buscando problemas na nave
    },
    methods: {
        ...shipHealthSvg,
        ...keyboardEvents,
        ...rotation,
        ...setShipSvgColor,
        ...handleDragMove,
        ...setShipSvgColorWithoutFlames,
        ...stopAndStartMoveShip,
        ...shakeShipRandomly,
        ...starMoveShipRandomly,
        ...setSpaceShipProblem,
        ...shipBackToMove,
        starDragEvent(event, index) {
            this.spaceShips[index].stopped = true
            this.spaceShips[index].animationRandom.stop()//Para a animacao aleatória da nave
            var angle = this.$refs.shipLayer[index].getNode().rotation()//Pega o angulo que ela estava por ultimo, quando estava fazendo rotacao randomica
            this.$refs.shipLayer[index].getNode().rotate(-angle)//Volta para o angulo zero
            this.shipBackToMove(index)

            return event, index
        },
        startMoveShip(event) {
            this.shipMoving = this.$refs.layer[event].getNode()
            this.idOfShipMoving = event
            this.spaceShips[this.idOfShipMoving].stopped = true
            this.spaceShips[this.idOfShipMoving].animationRandom.stop()//Para a animacao aleatória da nave
            var angle = this.$refs.shipLayer[event].getNode().rotation()//Pega o angulo que ela estava por ultimo, quando estava fazendo rotacao randomica
            this.$refs.shipLayer[event].getNode().rotate(-angle)//Volta para o angulo zero
            this.shipBackToMove(this.idOfShipMoving)
            this.$refs.textShipsName[event].getNode().visible(true)

            // this.spaceShips[this.idOfShipMoving].timeOut = setTimeout(() => {
            //     console.log("Voltando a mover a nave: " +this.idOfShipMoving)
            //     this.spaceShips[this.idOfShipMoving].animationRandom.start()
            //     this.spaceShips[this.idOfShipMoving].stopped = false
            // }, 3000);
            return event
        },
        //.Seta qual nave vai ser movida

        //Evento disparado quando o drag terminar(Quando parar de mexer com o mouse)
        handleDragEnd(event, index) {
            return event, index
        }

    }
};

</script>
<style lang="scss" scoped>


.hidden {
    display: none;
}
.button-active-maintanance {
    background-color: rgb(253, 194, 0);
    border: 2px solid blue;
    padding: 10px;
    border-radius: 5px;
    position: absolute;
    top: 20%;
    right: 50%;
}
.button-active-maintanance:disabled {
    background-color: rgb(241, 211, 110);
}
html {
    overflow: hidden;
}
html,
body {
    overflow: hidden;
}
</style>
