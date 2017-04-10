
-- -----------------------------------------------------
-- Table `Categories`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Categories` (
  `idcategories` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idcategories`) ,
  UNIQUE INDEX `idcategories_UNIQUE` (`idcategories` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Products` (
  `idproducts` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `code` VARCHAR(45) NOT NULL ,
  `price` FLOAT NOT NULL ,
  `image` MEDIUMBLOB NULL ,
  `categories_id` INT NOT NULL ,
  PRIMARY KEY (`idproducts`) ,
  UNIQUE INDEX `idproducts_UNIQUE` (`idproducts` ASC) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) ,
  INDEX `fk_products_categories1` (`categories_id` ASC) ,
  CONSTRAINT `fk_products_categories1`
    FOREIGN KEY (`categories_id` )
    REFERENCES `Categories` (`idcategories` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Orders`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Orders` (
  `idorders` INT NOT NULL AUTO_INCREMENT ,
  `return` TINYINT NOT NULL DEFAULT 0 ,
  `count` TINYINT NOT NULL DEFAULT 0 ,
  `discount` FLOAT NULL ,
  `products_id` INT NOT NULL ,
  PRIMARY KEY (`idorders`) ,
  UNIQUE INDEX `idtransactions_UNIQUE` (`idorders` ASC) ,
  INDEX `fk_Orderdetails_Products1` (`products_id` ASC) ,
  CONSTRAINT `fk_Orderdetails_Products1`
    FOREIGN KEY (`products_id` )
    REFERENCES `Products` (`idproducts` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Shops`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Shops` (
  `idshops` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `address` VARCHAR(90) NOT NULL ,
  PRIMARY KEY (`idshops`) ,
  UNIQUE INDEX `idshops_UNIQUE` (`idshops` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cashboxs`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Cashboxs` (
  `idcashboxs` INT NOT NULL AUTO_INCREMENT ,
  `id` INT NOT NULL ,
  `shops_id` INT NOT NULL ,
  PRIMARY KEY (`idcashboxs`) ,
  UNIQUE INDEX `idcashboxs_UNIQUE` (`idcashboxs` ASC) ,
  UNIQUE INDEX `cashboxid_UNIQUE` (`id` ASC) ,
  INDEX `fk_cashboxs_shops1` (`shops_id` ASC) ,
  CONSTRAINT `fk_cashboxs_shops1`
    FOREIGN KEY (`shops_id` )
    REFERENCES `Shops` (`idshops` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cashiers`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Cashiers` (
  `idcashiers` INT NOT NULL AUTO_INCREMENT ,
  `id` VARCHAR(45) NOT NULL ,
  `password` VARCHAR(45) NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `surname` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idcashiers`) ,
  UNIQUE INDEX `idcashiers_UNIQUE` (`idcashiers` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Transactions`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Transactions` (
  `idtransactions` INT NOT NULL AUTO_INCREMENT ,
  `cashboxs_id` INT NOT NULL ,
  `cashiers_id` INT NOT NULL ,
  `id` INT NOT NULL ,
  `date` TIMESTAMP NOT NULL ,
  `totalprice` FLOAT NOT NULL ,
  `discount` FLOAT NULL ,
  PRIMARY KEY (`idtransactions`) ,
  UNIQUE INDEX `idtransactions_UNIQUE` (`idtransactions` ASC) ,
  INDEX `fk_transactions_cashboxs1` (`cashboxs_id` ASC) ,
  INDEX `fk_transactions_cashiers1` (`cashiers_id` ASC) ,
  CONSTRAINT `fk_transactions_cashboxs1`
    FOREIGN KEY (`cashboxs_id` )
    REFERENCES `Cashboxs` (`idcashboxs` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transactions_cashiers1`
    FOREIGN KEY (`cashiers_id` )
    REFERENCES `Cashiers` (`idcashiers` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `OrdersToTransactions`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `OrdersToTransactions` (
  `orders_id` INT NOT NULL AUTO_INCREMENT ,
  `transactions_id` INT NOT NULL ,
  PRIMARY KEY (`orders_id`, `transactions_id`) ,
  INDEX `fk_Orderdetails_has_Transactions_Transactions1` (`transactions_id` ASC) ,
  INDEX `fk_Orderdetails_has_Transactions_Orderdetails1` (`orders_id` ASC) ,
  CONSTRAINT `fk_Orderdetails_has_Transactions_Orderdetails1`
    FOREIGN KEY (`orders_id` )
    REFERENCES `Orders` (`idorders` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Orderdetails_has_Transactions_Transactions1`
    FOREIGN KEY (`transactions_id` )
    REFERENCES `Transactions` (`idtransactions` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

