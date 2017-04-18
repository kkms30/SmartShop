
-- -----------------------------------------------------
-- Table `Categories`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Categories` (
  `idcategory` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idcategory`) ,
  UNIQUE INDEX `idcategories_UNIQUE` (`idcategory` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Products`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Products` (
  `idproduct` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `code` VARCHAR(45) NOT NULL ,
  `price` FLOAT NOT NULL ,
  `image` MEDIUMBLOB NULL ,
  `category_id` INT NOT NULL ,
  PRIMARY KEY (`idproduct`) ,
  UNIQUE INDEX `idproducts_UNIQUE` (`idproduct` ASC) ,
  UNIQUE INDEX `code_UNIQUE` (`code` ASC) ,
  INDEX `fk_products_categories1` (`category_id` ASC) ,
  CONSTRAINT `fk_products_categories1`
    FOREIGN KEY (`category_id` )
    REFERENCES `Categories` (`idcategory` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Shops`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Shops` (
  `idshop` INT NOT NULL AUTO_INCREMENT ,
  `name` VARCHAR(45) NOT NULL ,
  `address` VARCHAR(90) NOT NULL ,
  PRIMARY KEY (`idshop`) ,
  UNIQUE INDEX `idshops_UNIQUE` (`idshop` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cashboxes`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Cashboxes` (
  `idcashbox` INT NOT NULL AUTO_INCREMENT ,
  `id` INT NOT NULL ,
  `shop_id` INT NOT NULL ,
  PRIMARY KEY (`idcashbox`) ,
  UNIQUE INDEX `idcashboxs_UNIQUE` (`idcashbox` ASC) ,
  UNIQUE INDEX `cashboxid_UNIQUE` (`id` ASC) ,
  INDEX `fk_cashboxs_shops1` (`shop_id` ASC) ,
  CONSTRAINT `fk_cashboxs_shops1`
    FOREIGN KEY (`shop_id` )
    REFERENCES `Shops` (`idshop` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Cashiers`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Cashiers` (
  `idcashier` INT NOT NULL AUTO_INCREMENT ,
  `id` VARCHAR(45) NOT NULL ,
  `password` VARCHAR(45) NOT NULL ,
  `name` VARCHAR(45) NOT NULL ,
  `surname` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`idcashier`) ,
  UNIQUE INDEX `idcashiers_UNIQUE` (`idcashier` ASC) )
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Transactions`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Transactions` (
  `idtransaction` INT NOT NULL AUTO_INCREMENT ,
  `cashbox_id` INT NOT NULL ,
  `cashier_id` INT NOT NULL ,
  `id` INT NOT NULL ,
  `date` TIMESTAMP NOT NULL ,
  `totalprice` FLOAT NOT NULL ,
  `discount` FLOAT NULL ,
  PRIMARY KEY (`idtransaction`) ,
  UNIQUE INDEX `idtransactions_UNIQUE` (`idtransaction` ASC) ,
  INDEX `fk_transactions_cashboxs1` (`cashbox_id` ASC) ,
  INDEX `fk_transactions_cashiers1` (`cashier_id` ASC) ,
  CONSTRAINT `fk_transactions_cashboxs1`
    FOREIGN KEY (`cashbox_id` )
    REFERENCES `Cashboxes` (`idcashbox` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_transactions_cashiers1`
    FOREIGN KEY (`cashier_id` )
    REFERENCES `Cashiers` (`idcashier` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Orders`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `Orders` (
  `idorder` INT NOT NULL AUTO_INCREMENT ,
  `return` TINYINT NOT NULL DEFAULT 0 ,
  `count` TINYINT NOT NULL DEFAULT 0 ,
  `discount` FLOAT NULL ,
  `product_id` INT NOT NULL ,
  `transaction_id` INT NOT NULL ,
  PRIMARY KEY (`idorder`) ,
  UNIQUE INDEX `idtransactions_UNIQUE` (`idorder` ASC) ,
  INDEX `fk_Orderdetails_Products1` (`product_id` ASC) ,
  INDEX `fk_Orders_Transactions1` (`transaction_id` ASC) ,
  CONSTRAINT `fk_Orderdetails_Products1`
    FOREIGN KEY (`product_id` )
    REFERENCES `Products` (`idproduct` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Orders_Transactions1`
    FOREIGN KEY (`transaction_id` )
    REFERENCES `Transactions` (`idtransaction` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
