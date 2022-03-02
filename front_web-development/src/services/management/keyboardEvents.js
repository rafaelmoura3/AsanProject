export default {
  keyboardEvents (width, height) {
    height
    window.addEventListener('keydown', e => {
      //Usando teclado
      //Verifica se a nave chegou na posicao da manutencao e emite um evento qualquer
      //A ser tratado depois

      //.Verifica se a nave chegou na posicao da manutencao
      //Verifica se alguma nave foi clicada
      //se foi clicada, comeca a receber os eventos do teclado naquela nave
      //Movimento da nave pelo teclado
      //Se o id da nave for 0, provavelmente ele não entrará neste IF
      
      if (this.idOfShipMoving || this.idOfShipMoving == 0) {
        clearTimeout(this.spaceShips[this.idOfShipMoving].timeOut)
        if (
          this.shipMoving.x() > this.maintenanceAbsolutePosition.x &&
          this.shipMoving.y() > this.maintenanceAbsolutePosition.y
        ) {
          setTimeout(() => {
            if (
              this.shipMoving.x() > this.maintenanceAbsolutePosition.x &&
              this.shipMoving.y() > this.maintenanceAbsolutePosition.y
            ) {
              this.spaceShips[this.idOfShipMoving].isShipInMaintenance = true

              this.$emit('ableDialog', this.spaceShips[this.idOfShipMoving])
            } else {
              this.spaceShips[this.idOfShipMoving].isShipInMaintenance = false
            }
          }, 2000)
        } else {
          this.spaceShips[this.idOfShipMoving].isShipInMaintenance = false
        }
        if (e.key == 'ArrowRight') {
          //Para andar para direita, eu tenho que estar em um limite menor que  o tamanho total da tela
          if (this.shipMoving.x() < width - width / 10) {
            this.shipMoving.x(this.shipMoving.x() + this.speed)
            this.rotation(this.shipMoving, 'right', this.idOfShipMoving)
            //zero ele tá virado para esquerda
          }
        }
        if (e.key == 'ArrowLeft') {
          //Para andar para esquerda, eu tenho  que estar em um limite maior que o da esquerda
          if (this.shipMoving.x() >= this.limitLeft) {
            this.shipMoving.x(this.shipMoving.x() - this.speed)
            this.rotation(this.shipMoving, 'left', this.idOfShipMoving)
          }
        }
        if (e.key == 'ArrowDown') {
          //Para andar para baixo, eu tenho que estar com o limite menor que a altura total
          if (this.shipMoving.y() < this.limitDown - this.limitDown * 0.11) {
            this.shipMoving.y(this.shipMoving.y() + this.speed)
            this.rotation(this.shipMoving, 'down', this.idOfShipMoving)
          }
        }
        if (e.key == 'ArrowUp') {
          //Para andar para cima, eu tenho que estar com limite maior que a altura total dividida por 10 ou 20
          if (this.shipMoving.y() > this.limitTop) {
            this.shipMoving.y(this.shipMoving.y() - this.speed)
            this.rotation(this.shipMoving, 'up', this.idOfShipMoving)
          }
        }
      }
      //.Movimento da nave pelo teclado
    })
    window.addEventListener('keyup', () => {
      this.shipBackToMove(this.idOfShipMoving)
    })
  }
}
