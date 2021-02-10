# Use Cases

## 1) Present Shelf with Products

**Actor**: user

**Action**: Asks to see the shelf

**Steps**:

- Retrieve all products from the storage that have quantity greater than 0
- Remove the already reserved products.
- Display the list of products to the user.

## 2) Begin a new Order

**Actor**: user

**Action**: Asks to buy a product

**Steps**:

- Checks that the Product exists in the data storage
- Checks the availability of the Product (the quantity and if the product is already reserved by other Orders)
- Create a new Order for the product with state New.
  - This action automatically reserves the product.
- Redirects the user to the payment interface.

## 3) Begin a Payment

**Actor**: user

**Action**: Asks for the Order's Payment information.

**Steps**:

- Retrieve the Order details from the data storage.
- Display the payment information (from the Order)

## 4) Complete the Payment

**Actor**: user

**Action**: Asks to pay for a specific Order (perform the bank transfer)

**Steps**:

- Check that the specified Order exists in the data storage
- Perform the payment (maybe call an external service to perform the bank transfer)
- Change state of Order to Payed.
- Redirect the user to the Complete Sale interface.

## 5) Cancel Order

**Actor**: user

**Action**: Cancel an existing Order

**Steps**:

- Check that the specified Order exists in the data storage
- Check that the order was not payed yet.
- Check that the order was not canceled.
- Change state of Order to Canceled.

## 6) Complete an existing Order (Dispense the Product)

**Actor**: user

**Action**: Asks to receive the product for the payed Order

**Steps**:

- Check that the specified Order exists in the data storage
- Check that the payment was completed.
- Dispense the product.
- Change state of Order to Complete.

## 7) Display the list of orders

**Actor**: user

**Action**: Ask for the list of orders

**Steps**:

- Retrieve the list of orders from the data storage
- Display the list of orders to the user.