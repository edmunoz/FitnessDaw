SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `ProyectoWeb` ;
CREATE SCHEMA IF NOT EXISTS `ProyectoWeb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `ProyectoWeb` ;

-- -----------------------------------------------------
-- Table `ProyectoWeb`.`Usuario`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ProyectoWeb`.`Usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT ,
  `nick` VARCHAR(45) NOT NULL ,
  `correo` VARCHAR(50) NOT NULL ,
  `contrasena` VARCHAR(45) NOT NULL ,
  `edad` INT NOT NULL ,
  `peso` FLOAT NOT NULL ,
  `altura` FLOAT NOT NULL ,
  `fecha de registro` DATE NOT NULL ,
  PRIMARY KEY (`idUsuario`) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProyectoWeb`.`Articulo`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ProyectoWeb`.`Articulo` (
  `idArticulo` INT NOT NULL AUTO_INCREMENT ,
  `idRegistros` INT NOT NULL ,
  `tipo` VARCHAR(45) NOT NULL ,
  `titulo` VARCHAR(45) NOT NULL ,
  `descripcion` VARCHAR(2000) NOT NULL ,
  `imagen` VARCHAR(45) NOT NULL ,
  `fuente` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idArticulo`) ,
  INDEX `fk_Articulo_Usuario1_idx` (`idRegistros` ASC) ,
  CONSTRAINT `fk_Articulo_Usuario1`
    FOREIGN KEY (`idRegistros` )
    REFERENCES `ProyectoWeb`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProyectoWeb`.`Calendario`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ProyectoWeb`.`Calendario` (
  `idCalendario` INT NOT NULL AUTO_INCREMENT ,
  `idUsuario` INT NOT NULL ,
  PRIMARY KEY (`idCalendario`) ,
  INDEX `fk_Calendario_Usuario1_idx` (`idUsuario` ASC) ,
  CONSTRAINT `fk_Calendario_Usuario1`
    FOREIGN KEY (`idUsuario` )
    REFERENCES `ProyectoWeb`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `ProyectoWeb`.`Receta`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `ProyectoWeb`.`Receta` (
  `idRecetas` INT NOT NULL AUTO_INCREMENT ,
  `idUsuario` INT NOT NULL ,
  `idCalendario` INT NOT NULL ,
  `idRegistros` INT NOT NULL ,
  `titulo` VARCHAR(45) NOT NULL ,
  `descripcion` VARCHAR(2000) NOT NULL ,
  `calorias` FLOAT NOT NULL ,
  `proteinas` FLOAT NOT NULL ,
  `grasas` FLOAT NOT NULL ,
  `gramos` FLOAT NOT NULL ,
  `carboidratos` FLOAT NOT NULL ,
  `calificacion` INT NOT NULL ,
  PRIMARY KEY (`idRecetas`) ,
  INDEX `fk_Recetas_Calendario_idx` (`idCalendario` ASC) ,
  INDEX `fk_Receta_Usuario1_idx` (`idUsuario` ASC) ,
  CONSTRAINT `fk_Recetas_Calendario`
    FOREIGN KEY (`idCalendario` )
    REFERENCES `ProyectoWeb`.`Calendario` (`idCalendario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Receta_Usuario1`
    FOREIGN KEY (`idUsuario` )
    REFERENCES `ProyectoWeb`.`Usuario` (`idUsuario` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

USE `ProyectoWeb` ;

CREATE USER 'UsuarioDaw' IDENTIFIED BY 'daw';

GRANT SELECT, INSERT, TRIGGER ON TABLE `ProyectoWeb`.* TO 'UsuarioDaw';

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
