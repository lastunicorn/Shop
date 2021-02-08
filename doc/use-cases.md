# Use Cases

1. Display the Shelf with Products
2. Begin a new Sale
3. Begin a Payment
4. Complete the Payment
5. Complete an existing Sale (Dispense the Product)

## 1) Display the Shelf with Products

**Actor**: user

**Action**: Asks to see the list of products

**Steps**:

- Retrieve all products from the storage that have quantity greater than 0 and are not already reserved by other sales.
- Display the list of products to the user.

## 2) Begin a new Sale

**Actor**: user

**Action**: Asks to buy a product (Click on the "Buy" button)

**Steps**:

- Checks that the Product exists in the data storage
- Checks the availability of the Product (the quantity and if the product is already reserved by other Sales)
- Create a new Sale for the product with state New.
  - This action automatically reserves the product.
- Redirects the user to the payment interface.

## 3) Begin the Payment

**Actor**: user

**Action**: Asks to see the payment details for a specific Sale in order to perform the payment.

**Steps**:

- Retrieve the Sale details from the data storage
- Display the payment information (from the Sale)

## 4) Complete the Payment

**Actor**: user

**Action**: Asks to pay for a specific Sale (perform the bank transfer)

**Steps**:

- Check that the specified Sale exists in the data storage
- Perform the payment (maybe call an external service to perform the bank transfer)
- Change state of Sale to Payed.
- Redirect the user to the Complete Sale interface.

## 5) Complete an existing Sale (Dispense the Product)

**Actor**: user

**Action**: Asks to receive the product for the payed Sale

**Steps**:

- Check that the specified Sale exists in the data storage
- Check that the payment was completed.
- Dispense the product.
- Change state of Sale to Complete.