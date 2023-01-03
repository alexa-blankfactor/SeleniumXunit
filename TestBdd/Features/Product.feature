Feature: Product 
    Test the product page functionality

Background: Clean data
    Given I cleanup the following data
        | Name       | Description        | Price | ProductType |
        | Headphones | Noise cancellation | 300   | PERIPHARALS |
        | Monitor    | HD resolution monitor | 500   | PERIPHARALS |



Scenario: Create product and verify the details
    Given I click thew product menu
    And I click the "Create" link
    And I create product with following details 
        | Name       | Description        | Price | ProductType |
        | Headphones | Noise cancellation | 300   | PERIPHARALS |
    When I click the Details link of the newly created product 
    Then I see all the product details are created as expected
    And  I delete the product "Headphones" for cleanup


Scenario: Edit Product and verify if its updated
    Given I ensure the following product is created
        | Name    | Description | Price | ProductType |
        | Monitor | HD monitor  | 400   | MONITOR     |
    Given I click thew product menu
    When I click the Edit link of the newly created product
    And I Edit the product details with following
        | Name       | Description           | Price | ProductType |
        | Monitor    | HD resolution monitor | 500   | PERIPHARALS |
    And I click the Details link of the newly created product 
    Then I see all the product details are created as expected
    And  I delete the product "Monitor" for cleanup