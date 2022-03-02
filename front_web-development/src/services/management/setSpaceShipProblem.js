export default {
  async setSpaceShipProblem () {
    var problem = await this.serviceSetProblem.post({ ids: this.shipsInScreen})
    if(problem.data.status == false){
      return
    }
    // var problem = await this.serviceSetProblem.post()
    var shipWithProblem = await this.spaceshipService.getById(problem.data.spaceShipProblem.spaceShip.id)
    console.log("Problema na nave: "+problem.data.spaceShipProblem.spaceShip.id)
    this.spaceShipProblem = {
      spaceShipId: problem.data.spaceShipProblem.spaceShip.id,
      name: shipWithProblem.data.spaceShip.name,
      health: shipWithProblem.data.spaceShip.health,
      damage: problem.data.spaceShipProblem.damage,
      problemName: problem.data.spaceShipProblem.problem.name
    }
    for (let i = 0; i < this.spaceShips.length; i++) {
      if (
        this.spaceShips[i].spaceShip.id == this.spaceShipProblem.spaceShipId
      ) {
        let svg_health = this.shipHealthSvg(this.spaceShipProblem.health)
        let imageHealthPng = new window.Image()
        imageHealthPng.src = 'data:image/svg+xml;base64,' + btoa(svg_health)
        this.spaceShips[i].spaceshipHealthLayer.image = imageHealthPng
        this.spaceShips[i].shipConfig.maxRandom = 2
        this.spaceShips[i].shipConfig.minRandom = 1
        this.spaceshipsData.data[i].health = this.spaceShipProblem.health
      }
    }
    this.$emit('spaceShipProblem', this.spaceShipProblem)
  }
}
