export default {
  rotation (ship, size, id) {
    if (size == 'right') {
      if (this.spaceShips[id].shipConfig.angle == 0) {
        let rotate = 0
        setInterval(() => {
          if (rotate < 90) {
            ship.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 90
      }
      if (this.spaceShips[id].shipConfig.angle == 90) {
        this.spaceShips[id].shipConfig.angle = 90
      }
      if (this.spaceShips[id].shipConfig.angle == 180) {
        let rotate = 0
        setInterval(() => {
          if (rotate > -90) {
            ship.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        // ship.rotate(-90)

        this.spaceShips[id].shipConfig.angle = 90
      }
      if (this.spaceShips[id].shipConfig.angle == 270) {
        let rotate = 0
        setInterval(() => {
          if (rotate > -180) {
            ship.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 90
      }
    }
    if (size == 'left') {
      if (this.spaceShips[id].shipConfig.angle == 0) {
        let rotate = 0
        // ship.rotate(-90)
        setInterval(() => {
          if (rotate > -90) {
            ship.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)

        this.spaceShips[id].shipConfig.angle = 270
      }
      if (this.spaceShips[id].shipConfig.angle == 270) {
        this.spaceShips[id].shipConfig.angle = 270
      }
      if (this.spaceShips[id].shipConfig.angle == 90) {
        // ship.rotate(180)
        let rotate = 0
        setInterval(() => {
          if (rotate < 180) {
            ship.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)

        this.spaceShips[id].shipConfig.angle = 270
      }
      if (this.spaceShips[id].shipConfig.angle == 180) {
        // ship.rotate(90)
        let rotate = 0
        setInterval(() => {
          if (rotate < 90) {
            ship.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 270
      }
    }
    if (size == 'up') {
      if (this.spaceShips[id].shipConfig.angle == 0) {
        this.spaceShips[id].shipConfig.angle = 0
      }
      if (this.spaceShips[id].shipConfig.angle == 90) {
        // ship.rotate(-90)
        let rotate = 0
        setInterval(() => {
          if (rotate > -90) {
            ship.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 0
      }
      if (this.spaceShips[id].shipConfig.angle == 180) {
        // ship.rotate(-180)
        let rotate = 0
        setInterval(() => {
          if (rotate > -180) {
            ship.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 0
      }
      if (this.spaceShips[id].shipConfig.angle == 270) {
        let rotate = 0
        setInterval(() => {
          if (rotate < 90) {
            ship.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        // ship.rotate(-270)
        this.spaceShips[id].shipConfig.angle = 0
      }
    }
    if (size == 'down') {
      if (this.spaceShips[id].shipConfig.angle == 0) {
        let rotate = 0
        setInterval(() => {
          if (rotate < 180) {
            ship.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 180
      }
      if (this.spaceShips[id].shipConfig.angle == 270) {
        let rotate = 0
        setInterval(() => {
          if (rotate > -90) {
            ship.rotate(-10)
            rotate -= 10
          }
        }, this.rotationSpeed)
        // ship.rotate(-90)

        this.spaceShips[id].shipConfig.angle = 180
      }
      if (this.spaceShips[id].shipConfig.angle == 90) {
        // ship.rotate(90)
        let rotate = 0
        setInterval(() => {
          if (rotate < 90) {
            ship.rotate(10)
            rotate += 10
          }
        }, this.rotationSpeed)
        this.spaceShips[id].shipConfig.angle = 180
      }
      if (this.spaceShips[id].shipConfig.angle == 90) {
        this.spaceShips[id].shipConfig.angle = 180
      }
    }
  }
}
