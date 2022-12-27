Feature: Product 
    Test the product page functionality

Scenario: Create product and verify the details
    Given I click thew product menu
    And I click the "Create" link
    And I create product with following details 
        | Name       | Description        | Price | ProductType |
        | Headphones | Noise cancellation | 300   | PERIPHARALS |
    When I click the details link of the newly created product 
    Then I see all the product details are created as expected