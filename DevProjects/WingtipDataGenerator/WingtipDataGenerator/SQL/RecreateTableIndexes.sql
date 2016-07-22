

ALTER TABLE [Customers] ADD CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId]) 
ALTER TABLE [Invoices] ADD CONSTRAINT [PK_Invoices] PRIMARY KEY ([InvoiceId]) 
CREATE INDEX [IX_CustomerId] ON [Invoices]([CustomerId])
ALTER TABLE [InvoiceDetails] ADD CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY ([Id]) 
CREATE INDEX [IX_InvoiceId] ON [InvoiceDetails]([InvoiceId])
CREATE INDEX [IX_ProductId] ON [InvoiceDetails]([ProductId])
ALTER TABLE [Products] ADD CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])

ALTER TABLE [Invoices] ADD CONSTRAINT [FK_CustomerInvoices] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]) ON DELETE CASCADE
ALTER TABLE [InvoiceDetails] ADD CONSTRAINT [FK_InvoiceInvoiceDetails] FOREIGN KEY ([InvoiceId]) REFERENCES [Invoices] ([InvoiceId]) ON DELETE CASCADE
ALTER TABLE [InvoiceDetails] ADD CONSTRAINT [FK_ProductInvoiceDetails] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
