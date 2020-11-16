-- MySQL Script generated by MySQL Workbench
-- Thu Nov 14 14:04:15 2019
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`user` (
  `id` INT NOT NULL,
  `name` VARCHAR(45) NULL,
  `email` VARCHAR(45) NULL,
  `password` VARCHAR(45) NULL,
  `type` INT(1) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`camp_spot`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`camp_spot` (
  `no` INT NOT NULL AUTO_INCREMENT,
  `capacity` INT NOT NULL,
  `availability` CHAR BINARY NULL,
  `type` VARCHAR(45) NULL,
  PRIMARY KEY (`no`),
  UNIQUE INDEX `camp_no_UNIQUE` (`no` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`ticket`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`ticket` (
  `id` INT NOT NULL,
  `state` VARCHAR(45) NULL,
  `balance` DOUBLE NULL,
  `user_id` INT NOT NULL,
  `camp_spot_no` INT NOT NULL,
  PRIMARY KEY (`id`, `user_id`, `camp_spot_no`),
  INDEX `fk_ticket_user1_idx` (`user_id` ASC) VISIBLE,
  INDEX `fk_ticket_camp_spot1_idx` (`camp_spot_no` ASC) VISIBLE,
  CONSTRAINT `fk_ticket_user1`
    FOREIGN KEY (`user_id`)
    REFERENCES `mydb`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ticket_camp_spot1`
    FOREIGN KEY (`camp_spot_no`)
    REFERENCES `mydb`.`camp_spot` (`no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`transaction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`transaction` (
  `no` INT NOT NULL,
  `date_time` TIMESTAMP NULL,
  `ticket_id` INT NOT NULL,
  `ticket_user_id` INT NOT NULL,
  `ticket_camp_spot_no` INT NOT NULL,
  PRIMARY KEY (`no`, `ticket_id`, `ticket_user_id`, `ticket_camp_spot_no`),
  INDEX `fk_transaction_ticket1_idx` (`ticket_id` ASC, `ticket_user_id` ASC, `ticket_camp_spot_no` ASC) VISIBLE,
  CONSTRAINT `fk_transaction_ticket1`
    FOREIGN KEY (`ticket_id` , `ticket_user_id` , `ticket_camp_spot_no`)
    REFERENCES `mydb`.`ticket` (`id` , `user_id` , `camp_spot_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`product`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`product` (
  `no` INT NOT NULL,
  `name` VARCHAR(45) NULL,
  `price` DOUBLE NULL,
  `quantity` INT NULL,
  PRIMARY KEY (`no`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`item` (
  `no` INT NOT NULL,
  `name` VARCHAR(45) NULL,
  `price` DOUBLE NULL,
  `quantity` INT(10) NULL,
  PRIMARY KEY (`no`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`loan`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`loan` (
  `id` INT NOT NULL,
  `transaction_no` INT NOT NULL,
  `transaction_ticket_id` INT NOT NULL,
  `transaction_ticket_user_id` INT NOT NULL,
  `transaction_ticket_camp_spot_no` INT NOT NULL,
  PRIMARY KEY (`id`, `transaction_no`, `transaction_ticket_id`, `transaction_ticket_user_id`, `transaction_ticket_camp_spot_no`),
  INDEX `fk_loan_transaction1_idx` (`transaction_no` ASC, `transaction_ticket_id` ASC, `transaction_ticket_user_id` ASC, `transaction_ticket_camp_spot_no` ASC) VISIBLE,
  CONSTRAINT `fk_loan_transaction1`
    FOREIGN KEY (`transaction_no` , `transaction_ticket_id` , `transaction_ticket_user_id` , `transaction_ticket_camp_spot_no`)
    REFERENCES `mydb`.`transaction` (`no` , `ticket_id` , `ticket_user_id` , `ticket_camp_spot_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`shop`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`shop` (
  `id` INT NOT NULL,
  `transaction_no` INT NOT NULL,
  `transaction_ticket_id` INT NOT NULL,
  `transaction_ticket_user_id` INT NOT NULL,
  `transaction_ticket_camp_spot_no` INT NOT NULL,
  PRIMARY KEY (`id`, `transaction_no`, `transaction_ticket_id`, `transaction_ticket_user_id`, `transaction_ticket_camp_spot_no`),
  INDEX `fk_shop_transaction1_idx` (`transaction_no` ASC, `transaction_ticket_id` ASC, `transaction_ticket_user_id` ASC, `transaction_ticket_camp_spot_no` ASC) VISIBLE,
  CONSTRAINT `fk_shop_transaction1`
    FOREIGN KEY (`transaction_no` , `transaction_ticket_id` , `transaction_ticket_user_id` , `transaction_ticket_camp_spot_no`)
    REFERENCES `mydb`.`transaction` (`no` , `ticket_id` , `ticket_user_id` , `ticket_camp_spot_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`product_has_shop`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`product_has_shop` (
  `product_no` INT NOT NULL,
  `shop_id` INT NOT NULL,
  `shop_transaction_no` INT NOT NULL,
  `shop_transaction_ticket_id` INT NOT NULL,
  `shop_transaction_ticket_user_id` INT NOT NULL,
  `shop_transaction_ticket_camp_spot_no` INT NOT NULL,
  PRIMARY KEY (`product_no`, `shop_id`, `shop_transaction_no`, `shop_transaction_ticket_id`, `shop_transaction_ticket_user_id`, `shop_transaction_ticket_camp_spot_no`),
  INDEX `fk_product_has_shop_shop1_idx` (`shop_id` ASC, `shop_transaction_no` ASC, `shop_transaction_ticket_id` ASC, `shop_transaction_ticket_user_id` ASC, `shop_transaction_ticket_camp_spot_no` ASC) VISIBLE,
  INDEX `fk_product_has_shop_product1_idx` (`product_no` ASC) VISIBLE,
  CONSTRAINT `fk_product_has_shop_product1`
    FOREIGN KEY (`product_no`)
    REFERENCES `mydb`.`product` (`no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_product_has_shop_shop1`
    FOREIGN KEY (`shop_id` , `shop_transaction_no` , `shop_transaction_ticket_id` , `shop_transaction_ticket_user_id` , `shop_transaction_ticket_camp_spot_no`)
    REFERENCES `mydb`.`shop` (`id` , `transaction_no` , `transaction_ticket_id` , `transaction_ticket_user_id` , `transaction_ticket_camp_spot_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`loan_has_item`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`loan_has_item` (
  `loan_id` INT NOT NULL,
  `loan_transaction_no` INT NOT NULL,
  `loan_transaction_ticket_id` INT NOT NULL,
  `loan_transaction_ticket_user_id` INT NOT NULL,
  `loan_transaction_ticket_camp_spot_no` INT NOT NULL,
  `item_no` INT NOT NULL,
  PRIMARY KEY (`loan_id`, `loan_transaction_no`, `loan_transaction_ticket_id`, `loan_transaction_ticket_user_id`, `loan_transaction_ticket_camp_spot_no`, `item_no`),
  INDEX `fk_loan_has_item1_item1_idx` (`item_no` ASC) VISIBLE,
  INDEX `fk_loan_has_item1_loan1_idx` (`loan_id` ASC, `loan_transaction_no` ASC, `loan_transaction_ticket_id` ASC, `loan_transaction_ticket_user_id` ASC, `loan_transaction_ticket_camp_spot_no` ASC) VISIBLE,
  CONSTRAINT `fk_loan_has_item1_loan1`
    FOREIGN KEY (`loan_id` , `loan_transaction_no` , `loan_transaction_ticket_id` , `loan_transaction_ticket_user_id` , `loan_transaction_ticket_camp_spot_no`)
    REFERENCES `mydb`.`loan` (`id` , `transaction_no` , `transaction_ticket_id` , `transaction_ticket_user_id` , `transaction_ticket_camp_spot_no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_loan_has_item1_item1`
    FOREIGN KEY (`item_no`)
    REFERENCES `mydb`.`item` (`no`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
