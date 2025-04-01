-- Table structure for table menu
CREATE TABLE [menu] (
  [item_id] int NOT NULL IDENTITY(1,1),
  [name] varchar(30) NOT NULL,
  [description] varchar(50) NOT NULL,
  [price] int NOT NULL,
  [picture] varchar(50) NOT NULL,
  CONSTRAINT [PK_menu] PRIMARY KEY ([item_id])
);
GO

-- Table structure for table orders
CREATE TABLE [orders] (
  [order_id] int NOT NULL IDENTITY(1,1),
  [table_nr] int NOT NULL,
  [status] varchar(10) NOT NULL,
  [time] datetime NOT NULL DEFAULT GETDATE(),
  CONSTRAINT [PK_orders] PRIMARY KEY ([order_id])
);
GO

-- Table structure for table order_items
CREATE TABLE [order_items] (
  [order_id] int NOT NULL,
  [item_id] int NOT NULL,
  CONSTRAINT [PK_order_items] PRIMARY KEY ([order_id], [item_id])
);
GO

-- Table structure for table tables
CREATE TABLE [tables] (
  [table_nr] int NOT NULL IDENTITY(1,1),
  [status_table] varchar(10) NOT NULL,
  [waiter_id] int NOT NULL,
  CONSTRAINT [PK_tables] PRIMARY KEY ([table_nr])
);
GO

-- Table structure for table users
CREATE TABLE [users] (
  [id] int NOT NULL IDENTITY(1,1),
  [username] varchar(50) NOT NULL,
  [password] varchar(50) NOT NULL,
  [type] varchar(50) NOT NULL,
  CONSTRAINT [PK_users] PRIMARY KEY ([id])
);
GO

-- Create unique constraint on username
CREATE UNIQUE INDEX [UX_username] ON [users]([username]);
GO

-- Table structure for table waiters
CREATE TABLE [waiters] (
  [id] int NOT NULL IDENTITY(1,1),
  [order_id] int NULL,
  [user_id] int NOT NULL,
  CONSTRAINT [PK_waiters] PRIMARY KEY ([id])
);
GO

-- Insert data into users table
INSERT INTO [users] ([username], [password], [type]) VALUES
('razvan', 'password', 'waiter'),
('macheciau', 'parola123', 'manager');
GO

-- Add foreign key constraints
ALTER TABLE [orders]
  ADD CONSTRAINT [fk_orders_table] FOREIGN KEY ([table_nr]) REFERENCES [tables] ([table_nr]);
GO

ALTER TABLE [order_items]
  ADD CONSTRAINT [fk_order_items_item] FOREIGN KEY ([item_id]) REFERENCES [menu] ([item_id]),
  CONSTRAINT [fk_order_items_order] FOREIGN KEY ([order_id]) REFERENCES [orders] ([order_id]);
GO

ALTER TABLE [tables]
  ADD CONSTRAINT [fk_tables_waiter] FOREIGN KEY ([waiter_id]) REFERENCES [waiters] ([id]);
GO

ALTER TABLE [waiters]
  ADD CONSTRAINT [fk_waiter_order] FOREIGN KEY ([order_id]) REFERENCES [orders] ([order_id]) ON DELETE SET NULL,
  CONSTRAINT [fk_waiter_user] FOREIGN KEY ([user_id]) REFERENCES [users] ([id]);
GO