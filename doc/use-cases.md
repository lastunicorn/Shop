# Use Cases

## 1) Present Shelf with Products

**Actor**: user

**Action**: Asks to see the shelf

**Steps**:

- Retrieve all products from the storage that have quantity greater than 0 and are not reserved for other orders.
- Display the list of products to the user.

## 2) Begin a new Order

**Actor**: user

**Action**: Asks to buy a product

**Steps**:

- Retrieve product from data storage.
- Checks the availability of the Product
  - The quantity minus the products that are already reserved by other Orders must be greater or equal to 1
- Create a new Order for the product with state New.
  - This action automatically reserves the product.
- Redirects the user to the payment interface.

**Alternate flows**:

- If product does not exist
  - Display "Product missing" error to the user.
- If available product quantity is 0
  - Display "Insufficient quantity" error to the user.

## 3) Begin a Payment

**Actor**: user

**Action**: Asks for the Order's Payment information.

**Steps**:

- Retrieve the Order from the data storage.
- Validate that the order is ready for payment
  - Must be in state New.
- Display the payment information (from the Order)

**Alternate flows**:

- If specified order does not exist
  - Display "Order missing" error to the user.
- If order is in state Payed or Done
  - Display "Payment already completed" error to the user.
- If order is in state Cancelled
  - Display "Payment was cancelled" error to the user.

## 4) Complete the Payment

**Actor**: user

**Action**: Asks to pay for a specific Order (perform the bank transfer)

**Steps**:

- Retrieve the Order from the data storage.
- Validate that the order is ready for payment
  - Must be in state New.
- Perform the payment (maybe call an external service to perform the bank transfer)
- Change state of Order to Payed.
- Redirect the user to the Complete Sale interface.

**Alternate flows**:

- If specified order does not exist
  - Display "Order missing" error to the user.
- If order is in state Payed or Done
  - Display "Payment already completed" error to the user.
- If order is in state Cancelled
  - Display "Payment was cancelled" error to the user.

## 5) Cancel Order

**Actor**: user

**Action**: Cancel an existing Order

**Steps**:

- Retrieve the Order from the data storage.
- Validate that the order is ready for payment
  - Must be in state New.
- Change state of Order to Cancelled.

**Alternate flows**:

- If specified order does not exist
  - Display "Order missing" error to the user.

- If order is in state Payed or Done
  - Display "Payment already completed" error to the user.
- If order is in state Cancelled
  - Display "Payment was cancelled" error to the user.

## 6) Complete an existing Order (Dispense the Product)

**Actor**: user

**Action**: Asks to receive the product for the payed Order

**Steps**:

- Retrieve the Order from the data storage.
- Validate that the order is ready for payment
  - Must be in state Payed.
- Dispense the product.
  - Decrement quantity
- Change state of Order to Done.

**Alternate flows**:

- If specified order does not exist
  - Display "Order missing" error to the user.

- If order is in state New
  - Display "Order not payed" error to the user.
- If order is in state Done
  - Display "Product already dispensed" error to the user.
- If order is in state Cancelled
  - Display "Payment was cancelled" error to the user.

## 7) Display the list of orders

**Actor**: user

**Action**: Ask for the list of orders

**Steps**:

- Retrieve the list of orders from the data storage.
- Display the list of orders to the user.