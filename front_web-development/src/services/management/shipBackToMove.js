import Konva from "konva"
export default {
  shipBackToMove (shipId) {
   
    this.spaceShips[shipId].timeOut = setTimeout(() => {
      this.$refs.textShipsName[shipId].getNode().visible(false)
      if (
        this.spaceShips[shipId].shipConfig.angle == 0 &&
        this.spaceShips[shipId].direction == 'right'
      ) {
        let rotate = 0
        setInterval(() => {
          if (rotate < 90) {
            this.spaceShips[shipId].layer.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[shipId].shipConfig.angle = 90
      }
      if (
        this.spaceShips[shipId].shipConfig.angle == 0 &&
        this.spaceShips[shipId].direction == 'left'
      ) {
        let rotate = 0
        setInterval(() => {
          if (rotate > -90) {
            this.spaceShips[shipId].layer.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        this.spaceShips[shipId].shipConfig.angle = 270
      }
      if (
        this.spaceShips[shipId].shipConfig.angle == 180 &&
        this.spaceShips[shipId].direction == 'left'
      ) {
        let rotate = 0
        setInterval(() => {
          if (rotate < 90) {
            this.spaceShips[shipId].layer.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[shipId].shipConfig.angle = 270
      }
      if (
        this.spaceShips[shipId].shipConfig.angle == 270 &&
        this.spaceShips[shipId].direction == 'right'
      ) {
        let rotate = 0
        setInterval(() => {
          if (rotate < 180) {
            this.spaceShips[shipId].layer.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[shipId].shipConfig.angle = 90
      }
      if (
        this.spaceShips[shipId].shipConfig.angle == 180 &&
        this.spaceShips[shipId].direction == 'right'
      ) {
        let rotate = 0
        setInterval(() => {
          if (rotate > -90) {
            this.spaceShips[shipId].layer.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        this.spaceShips[shipId].shipConfig.angle = 90
      }
      setTimeout(() => {
        const speedDefault = 0.01
        let anim1 = new Konva.Animation(() => {
          let defaultSpeedForThisShip
        if (this.spaceshipsData.data[shipId].health <= 50) {
          defaultSpeedForThisShip = 0.5
        } else {
          defaultSpeedForThisShip =
            this.spaceshipsData.data[shipId].health * speedDefault
        }
          if (
            this.spaceShips[shipId].layer.getY() >
              this.spaceShips[shipId].startPositionY &&
            this.spaceShips[shipId].stopped == false &&
            this.spaceShips[shipId].isShipInMaintenance == false
          ) {
            this.spaceShips[shipId].layer.setY(
              this.spaceShips[shipId].layer.getY() - defaultSpeedForThisShip
            )
          }

          if (
            this.spaceShips[shipId].layer.getY() <
              this.spaceShips[shipId].startPositionY &&
            this.spaceShips[shipId].stopped == false &&
            this.spaceShips[shipId].isShipInMaintenance == false
          ) {
            this.spaceShips[shipId].layer.setY(
              this.spaceShips[shipId].layer.getY() + defaultSpeedForThisShip
            )
          }
          // }
          return defaultSpeedForThisShip
        })

        anim1.start()
        this.spaceShips[shipId].animationRandom.start()
        this.spaceShips[shipId].stopped = false
      }, 2000)
    }, 3000)
  }
}
