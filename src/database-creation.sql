CREATE TABLE [PaidBy] (
          [Id] uniqueidentifier NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [Description] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_PaidBy] PRIMARY KEY ([Id])
      );

      CREATE TABLE [Account] (
          [Id] uniqueidentifier NOT NULL,
          [Number] int NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [Description] nvarchar(max) NOT NULL,
          [Balance] decimal(18,2) NOT NULL,
          [IsUsed] bit NOT NULL,
          [CategoryId] uniqueidentifier NOT NULL,
          [CreatedByUserId] uniqueidentifier NOT NULL,
          CONSTRAINT [PK_Account] PRIMARY KEY ([Id])
      );

      CREATE TABLE [User] (
          [Id] uniqueidentifier NOT NULL,
          [UserName] nvarchar(max) NOT NULL,
          [NameFirst] nvarchar(max) NOT NULL,
          [NameLast] nvarchar(max) NOT NULL,
          [Email] nvarchar(max) NOT NULL,
          [Password] nvarchar(max) NOT NULL,
          [PasswordSalt] nvarchar(max) NOT NULL,
          [PasswordHash] nvarchar(max) NOT NULL,
          [Role] nvarchar(max) NOT NULL,
          [AccountId] uniqueidentifier NULL,
          CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_User_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id])
      );

      CREATE TABLE [Category] (
          [Id] uniqueidentifier NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [Description] nvarchar(max) NOT NULL,
          [UserId] uniqueidentifier NULL,
          CONSTRAINT [PK_Category] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Category_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id])
      );

      CREATE TABLE [PaidByUser] (
          [PaidByGroupsId] uniqueidentifier NOT NULL,
          [UsersGroupId] uniqueidentifier NOT NULL,
          CONSTRAINT [PK_PaidByUser] PRIMARY KEY ([PaidByGroupsId], [UsersGroupId]),
          CONSTRAINT [FK_PaidByUser_PaidBy_PaidByGroupsId] FOREIGN KEY ([PaidByGroupsId]) REFERENCES [PaidBy] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_PaidByUser_User_UsersGroupId] FOREIGN KEY ([UsersGroupId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [TransactionCategory] (
          [Id] uniqueidentifier NOT NULL,
          [UserId] uniqueidentifier NOT NULL,
          CONSTRAINT [PK_TransactionCategory] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_TransactionCategory_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [CategoryTransactionCategory] (
          [CategoriesId] uniqueidentifier NOT NULL,
          [TransactionCategoriesId] uniqueidentifier NOT NULL,
          CONSTRAINT [PK_CategoryTransactionCategory] PRIMARY KEY ([CategoriesId], [TransactionCategoriesId]),
          CONSTRAINT [FK_CategoryTransactionCategory_Category_CategoriesId] FOREIGN KEY ([CategoriesId]) REFERENCES [Category] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_CategoryTransactionCategory_TransactionCategory_TransactionCategoriesId] FOREIGN KEY ([TransactionCategoriesId]) REFERENCES [TransactionCategory] ([Id]) ON DELETE NO ACTION
      );

      CREATE TABLE [Transaction] (
          [Id] uniqueidentifier NOT NULL,
          [Name] nvarchar(max) NOT NULL,
          [Description] nvarchar(max) NOT NULL,
          [Amount] decimal(18,2) NOT NULL,
          [DateAccounting] datetime2 NOT NULL,
          [DateTransaction] datetime2 NOT NULL,
          [DateCurrency] datetime2 NOT NULL,
          [AccountId] uniqueidentifier NOT NULL,
          [TransactionCategoryId] uniqueidentifier NOT NULL,
          [UserId] uniqueidentifier NOT NULL,
          [PaidById] uniqueidentifier NOT NULL,
          CONSTRAINT [PK_Transaction] PRIMARY KEY ([Id]),
          CONSTRAINT [FK_Transaction_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_Transaction_PaidBy_PaidById] FOREIGN KEY ([PaidById]) REFERENCES [PaidBy] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_Transaction_TransactionCategory_TransactionCategoryId] FOREIGN KEY ([TransactionCategoryId]) REFERENCES [TransactionCategory] ([Id]) ON DELETE NO ACTION,
          CONSTRAINT [FK_Transaction_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE NO ACTION
      );