import Konva from "konva";
export default{
    shakeShipRandomly() {
        for (let i = 0; i < this.spaceShips.length; i++) {
            var animationRandom = new Konva.Animation(() => {
                var teste = this.$refs.shipLayer[i].getNode()
                if (this.spaceShips[i].animationRandomStopped == false || this.spaceShips[i].animationRandomStopped == null) {
                    if(this.spaceShips[i].isShipInMaintenance){
                        return
                    }
                    let min = Math.ceil(this.spaceShips[i].shipConfig.minRandom);
                    let max = Math.floor(this.spaceShips[i].shipConfig.maxRandom);
                    teste.rotate(Math.floor(Math.random() * (max - min + 1)) + min)
                    teste.rotate(-(Math.floor(Math.random() * (max - min + 1)) + min))
                }
            });
            this.spaceShips[i].animationRandom = animationRandom;
            this.spaceShips[i].animationRandom.start()
        }
    },
}