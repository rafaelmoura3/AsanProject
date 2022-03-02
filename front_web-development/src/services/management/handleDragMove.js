export default {
  handleDragMove (event, index) {
    this.layers = this.$refs.layer
    this.shipMoving = this.layers[index].getNode()
    this.shipMoving.x(event.evt.layerX)
    this.shipMoving.y(event.evt.layerY)
    this.spaceShips[index].stopped = true
    clearTimeout(this.spaceShips[index].timeOut)
    if (
      this.shipMoving.x() > this.maintenanceAbsolutePosition.x &&
      this.shipMoving.y() > this.maintenanceAbsolutePosition.y
    ) {
      setTimeout(() => {
        if (
          this.shipMoving.x() > this.maintenanceAbsolutePosition.x &&
          this.shipMoving.y() > this.maintenanceAbsolutePosition.y
        ) {
          this.spaceShips[index].isShipInMaintenance = true
          this.$emit('ableDialog', this.spaceShips[index])
        } else {
          this.spaceShips[index].isShipInMaintenance = false
        }
      }, 2000)
    } else {
      this.spaceShips[index].isShipInMaintenance = false
    }
    this.shipBackToMove(index)

    // if (
    //   this.shipMoving.absolutePosition().x >
    //   this.windowWidth - this.windowWidth / 20
    // ) {
    //   this.shipMoving.stopDrag()
    //   this.shipMoving.x(this.shipMoving.x() - this.windowWidth / 20)
    // }
    // if (this.shipMoving.absolutePosition().x <= this.windowWidth / 20) {
    //   this.shipMoving.stopDrag()
    //   this.shipMoving.x(this.shipMoving.x() + this.windowWidth / 20)
    // }
    // if (this.shipMoving.absolutePosition().y <= this.windowHeigth / 20) {
    //   this.shipMoving.stopDrag()
    //   this.shipMoving.y(this.shipMoving.y() + this.windowHeigth / 20)
    // }
    // if (
    //   this.shipMoving.absolutePosition().y >=
    //   this.windowHeigth - this.windowHeigth / 25
    // ) {
    //   this.shipMoving.stopDrag()
    //   this.shipMoving.y(this.shipMoving.y() - this.windowHeigth / 20)
    // }

    return event
  }
}
