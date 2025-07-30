
# 📊 System Design - Technical Perspective

## 📦 Entities (Data Models)

### Provider
- `id`: Unique identifier
- `name`: Provider name

### Client
- `id`: Unique identifier
- `name`: Client name
- `outstanding_balance`: Total unpaid balance

### Item
- `id`: Unique identifier
- `name`: Item name

### Collection
- `id`: Unique identifier
- `client`: Reference to Client
- `amount`: Amount paid
- `date`: Payment date

### Order
- `id`: Unique identifier
- `client`: Reference to Client
- `item`: Reference to Item
- `units`: Quantity ordered
- `unit_price`: Price per unit
- `date`: Order date
- `total`: Calculated as `units * unit_price`
- `collected`: Amount collected so far for the order

### Purchase
- `id`: Unique identifier
- `provider`: Reference to Provider
- `item`: Reference to Item
- `units`: Quantity purchased
- `unit_price`: Price per unit
- `date`: Purchase date

---

## 🔧 Features

### Data Entry
- `Add Collection`: Store new payment from a client
- `Add Order`: Store new order from a client
- `Add Purchase`: Store new stock acquisition from a provider

### Reporting
- `a. Today's Purchases`: Filter purchases by current date
- `b. Today's Collections`: Filter collections by current date
- `c. Purchases from Specific Provider`: Query by provider ID
- `d. Collections from Specific Client`: Query by client ID

---

## 🗄️ Possible Tables/Schema Design

Each entity can map to a relational table in SQL (e.g., PostgreSQL, MSSQL):

- `providers(id, name)`
- `clients(id, name, outstanding_balance)`
- `items(id, name)`
- `collections(id, client_id, amount, date)`
- `orders(id, client_id, item_id, units, unit_price, date, total, collected)`
- `purchases(id, provider_id, item_id, units, unit_price, date)`

Ensure foreign key relationships and indexing for performance.

---

## 🧪 Considerations

- Input validation (e.g., positive numbers for `units`, `price`)
- Atomicity for `orders` and `collections`
- Date/time consistency (UTC vs local)
- Error handling and logging

