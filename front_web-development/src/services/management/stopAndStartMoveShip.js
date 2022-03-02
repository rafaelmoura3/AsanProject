export default{
    stopAndStartMoveShip() {
        for (let i = 0; i < this.spaceshipsData.data.length; i++) {
            setInterval(() => {
                if(!this.spaceShips[i]?.shipConfig)return
                if (!this.spaceShips[i].shipConfig.flames || this.spaceShips[i].shipConfig.flames == null) {
                    this.spaceShips[i].shipConfig.image = this.spaceShips[i].shipConfig.imageWithFlames
                    this.spaceShips[i].shipConfig.flames = true
                }
                else {
                    this.spaceShips[i].shipConfig.image = this.spaceShips[i].shipConfig.imageWithoutFlames
                    this.spaceShips[i].shipConfig.flames = false
                }
            }, 10);
        }
    },
}