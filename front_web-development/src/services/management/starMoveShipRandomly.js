import Konva from 'konva'
export default {
  starMoveShipRandomly () {
    const widthCanvas = this.$refs.stage.getNode().getWidth()
    const speedDefault = 0.01 //Velocidade padrao com que a nave se move
    var layers = this.$refs.layer
    for (let i = 0; i < layers.length; i++) {
      let layer = layers[i].getNode()
      this.spaceShips[i].direction = 'right'
      let anim1 = new Konva.Animation(() => {
        // let defaultSpeedForThisShip = this.spaceshipsData.data[i].health * speedDefault
        let defaultSpeedForThisShip
        if (this.spaceshipsData.data[i].health <= 50) {
          defaultSpeedForThisShip = 0.5
        } else {
          defaultSpeedForThisShip =
            this.spaceshipsData.data[i].health * speedDefault
        }
        if (
          (this.spaceShips[i].isShipInMaintenance == false &&
            this.spaceShips[i].stopped == false) ||
          this.spaceShips[i].stopped == null
        ) {
          if (
            this.spaceShips[i].layer.getX() >=
              widthCanvas + this.widthImage * 2 &&
            this.spaceShips[i].direction == 'right'
          ) {
            this.spaceShips[i].direction = 'left'
          }
          if (
            this.spaceShips[i].layer.getX() < 0 - this.widthImage * 2 &&
            this.spaceShips[i].direction == 'left'
          ) {
            this.spaceShips[i].direction = 'right'
          }
          if (this.spaceShips[i].direction == 'right') {
            this.spaceShips[i].layer.setX(
              this.spaceShips[i].layer.getX() + defaultSpeedForThisShip
            )
            this.spaceShips[i].layer.rotation(90)
            this.spaceShips[i].shipConfig.angle = 90
          }
          if (this.spaceShips[i].direction == 'left') {
            this.spaceShips[i].layer.setX(
              this.spaceShips[i].layer.getX() - defaultSpeedForThisShip
            )
            this.spaceShips[i].layer.rotation(-90)
            this.spaceShips[i].shipConfig.angle = 270
          }
        }
      })
      this.spaceShips[i].layer = layer
      this.spaceShips[i].animation = anim1
      this.spaceShips[i].animation.start()
    }
  }
}
