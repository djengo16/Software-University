function createMixins() {
    function computerQualityMixin(classToExtend){
        classToExtend.prototype.getQuality = function(){
            return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3;
        }

        classToExtend.prototype.isFast = function(){
            return this.processorSpeed > (this.ram / 4);
        }

        classToExtend.prototype.isRoomy = function(){
            return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed);
        }

    }

    function styleMixin(classToExtend){
        classToExtend.prototype.isFullSet = function(){
            let computerManufacturer = this.manufacturer;
            let keybManufacturer = this.keyboard.manufacturer;
            let monitorManufacturer = this.monitor.manufacturer;

            if(computerManufacturer == keybManufacturer &&
                keybManufacturer == monitorManufacturer &&
                monitorManufacturer == computerManufacturer){
                    return true;
                }else{
                    return false;
                }
        }

        classToExtend.prototype.isClassy = function(){
            let batteryLife = this.battery.expectedLife;
            let color = this.color.toLowerCase();
            let weight = this.weight;
            if(batteryLife >= 3 && ['silver','black'].includes(color) && weight < 3 ){
                return true;
            }else{
                return false;
            }
        }
    }


    return {
        computerQualityMixin,
        styleMixin
    }
}
