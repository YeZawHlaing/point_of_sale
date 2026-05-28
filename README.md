# POS System: Use Cases, User Flows, and Technical Implementation

This document contains the functional specifications, architectural documentation, and implementation details for the C# Windows Forms and Microsoft SQL Server Point of Sale (POS) application.

---

## 👥 Use Case Diagram & Descriptions

In a typical retail POS environment, your system interacts with two main actors: the **Cashier** (front-of-house operations) and the **Admin** (back-of-house management).


---
## 2. Use Case Inventory

| Use Case ID | Use Case Name | Primary Actor | Description |
| :--- | :--- | :--- | :--- |
| **UC-01** | Authenticate User | Cashier / Admin | User logs into the system using their unique credentials. |
| **UC-02** | Process Sale / Checkout | Cashier | Items are scanned/added, discounts applied, and payment is processed. |
| **UC-03** | Manage Inventory | Admin | Admin adds, updates, or adjusts product details and stock thresholds. |
| **UC-04** | View Low-Stock Alerts | Cashier / Admin | System notifies the user when items drop below safety thresholds. |
| **UC-05** | Generate Reports | Admin | Analytics on sales, revenue, and daily financial summaries are built. |
---


