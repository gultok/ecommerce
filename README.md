# ecommerce

ECommerce solution has 2 main projects and 2 test projects. 

	ECommerce.CommandRunner is a console application. That application read scenario text files and run commands.
	ECommerce.Api is an API project. That api is a layer for do your operations.
	ECommerce.Core is an class project and it is business logic layer.
	ECommerce.Core.Test is a unit test project for ECommerce.Core business layer. You can test your scenarios expected results.
	ECommerce.Api.Test is an api unit test project for ECommerce.Api endpoints. You can test api endpoints with valid and invalid datas. 

# You can
	Create Product, 
	Get Product Info, 
	Create Campaign,
	Get Campaign Info,
	Create Order,
	Increase Time

You can do that operations with 2 ways: 
## 1) create text file with your commands 
		"create_product PRODUCTCODE PRICE STOCK", 
		"get_product_info PRODUCTCODE", 
		"create_campaign NAME PRODUCTCODE DURATION LIMIT TARGETSALESCOUNT", 
		"get_campaign_info NAME", 
		"create_order PRODUCTCODE QUANTITY", 
		"increase_time HOUR"
  and add that file into ECommerce.CommandRunner project folder with name like "Scenario...".
  Before run ECommerce.CommandRunner, run ECommerce.Api project.

## 2) run ECommerce.Api and call api endpoints.
	Get Product Info	
		method: Get, url endpoint: /products/{productcode}
	Create Product
		method: Post, url endpoint: /products body: {"ProductCode": "", "Stock": 0, "Price": 0}
	Get Campaign Info
		method: Get url endpoint: /campaigns/{campaigname}
	Create Campaign
		method: Post, url endpoint: /campaigns body: {"Name": "", "ProductCode": "", "Duration": 0, "Limit": 0, "TargetSalesCount": 0}
	Create Order
		method: Post, url endpoint: /orders body: {"ProductCode": "", "Quantity": 0 }
	Increase Time
		method: Post, url endpoint: /time/increase-time/{hours}
