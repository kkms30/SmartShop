
-- -----------------------------------------------------
-- Table `categories`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `categories` (
  `idcategories` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idcategories`) ,
  UNIQUE INDEX `idcategories_UNIQUE` (`idcategories` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `products` (
  `idproducts` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `code` VARCHAR(45) NOT NULL ,
  `price` FLOAT NOT NULL ,
  `image` MEDIUMBLOB NULL ,
  `categories_idcategories` INT NOT NULL ,
  PRIMARY KEY (`idproducts`) ,
  UNIQUE INDEX `idproducts_UNIQUE` (`idproducts` ASC) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) ,
  INDEX `fk_products_categories1` (`categories_idcategories` ASC) ,
  CONSTRAINT `fk_products_categories1`
    FOREIGN KEY (`categories_idcategories` )
    REFERENCES `categories` (`idcategories` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `orderdetails`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `orderdetails` (
  `idorderdetails` INT NOT NULL AUTO_INCREMENT ,
  `id` INT NOT NULL ,
  `return` TINYINT NOT NULL DEFAULT 0 ,
  `count` TINYINT NOT NULL DEFAULT 0 ,
  `discount` FLOAT NULL ,
  `categories_idcategories` INT NOT NULL ,
  PRIMARY KEY (`idorderdetails`) ,
  UNIQUE INDEX `idtransactions_UNIQUE` (`idorderdetails` ASC) ,
  INDEX `fk_orderdetails_categories1` (`categories_idcategories` ASC) ,
  CONSTRAINT `fk_orderdetails_categories1`
    FOREIGN KEY (`categories_idcategories` )
    REFERENCES `categories` (`idcategories` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `shops`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `shops` (
  `idshops` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `address` VARCHAR(90) NOT NULL ,
  PRIMARY KEY (`idshops`) ,
  UNIQUE INDEX `idshops_UNIQUE` (`idshops` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `cashboxs`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `cashboxs` (
  `idcashboxs` INT NOT NULL AUTO_INCREMENT ,
  `id` INT NOT NULL ,
  `shops_idshops` INT NOT NULL ,
  PRIMARY KEY (`idcashboxs`) ,
  UNIQUE INDEX `idcashboxs_UNIQUE` (`idcashboxs` ASC) ,
  UNIQUE INDEX `cashboxid_UNIQUE` (`id` ASC) ,
  INDEX `fk_cashboxs_shops1` (`shops_idshops` ASC) ,
  CONSTRAINT `fk_cashboxs_shops1`
    FOREIGN KEY (`shops_idshops` )
    REFERENCES `shops` (`idshops` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `cashiers`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `cashiers` (
  `idcashiers` INT NOT NULL AUTO_INCREMENT ,
  `id` VARCHAR(45) NOT NULL ,
  `password` VARCHAR(45) NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `surname` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idcashiers`) ,
  UNIQUE INDEX `idcashiers_UNIQUE` (`idcashiers` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `transactions`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `transactions` (
  `idtransactions` INT NOT NULL AUTO_INCREMENT ,
  `orderdetails_idorderdetails` INT NOT NULL ,
  `cashboxs_idcashboxs` INT NOT NULL ,
  `cashiers_idcashiers` INT NOT NULL ,
  `id` INT NOT NULL ,
  `date` TIMESTAMP NOT NULL ,
  `totalprice` FLOAT NOT NULL ,
  `discount` FLOAT NULL ,
  PRIMARY KEY (`idtransactions`) ,
  UNIQUE INDEX `idtransactions_UNIQUE` (`idtransactions` ASC) ,
  INDEX `fk_transactions_orderdetails1` (`orderdetails_idorderdetails` ASC) ,
  INDEX `fk_transactions_cashboxs1` (`cashboxs_idcashboxs` ASC) ,
  INDEX `fk_transactions_cashiers1` (`cashiers_idcashiers` ASC) ,
  CONSTRAINT `fk_transactions_orderdetails1`
    FOREIGN KEY (`orderdetails_idorderdetails` )
    REFERENCES `orderdetails` (`id` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transactions_cashboxs1`
    FOREIGN KEY (`cashboxs_idcashboxs` )
    REFERENCES `cashboxs` (`idcashboxs` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transactions_cashiers1`
    FOREIGN KEY (`cashiers_idcashiers` )
    REFERENCES `cashiers` (`idcashiers` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = MyISAM;