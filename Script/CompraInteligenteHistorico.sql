CREATE TABLE CompraInteligenteHistorico (
    [Id] [smallint] IDENTITY(1,1) NOT NULL,
    Nome VARCHAR(255) NOT NULL,
    Quantidade INT NOT NULL,
    DataCompra DATE NOT NULL,
    Preco DECIMAL(10, 2) NOT NULL,
	PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO CompraInteligenteHistorico (Nome, Quantidade, DataCompra, Preco)
VALUES
    ('Produto 1', 10, '2023-01-01', 25.99),
    ('Produto 2', 5, '2023-01-02', 12.49),
    ('Produto 3', 8, '2023-01-03', 19.99),
    ('Produto 4', 12, '2023-01-04', 8.99),
    ('Produto 5', 15, '2023-01-05', 34.99),
    ('Produto 6', 7, '2023-01-06', 9.99),
    ('Produto 7', 20, '2023-01-07', 42.99),
    ('Produto 8', 3, '2023-01-08', 6.99),
    ('Produto 9', 11, '2023-01-09', 15.99),
    ('Produto 10', 6, '2023-01-10', 27.99);
