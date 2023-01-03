command to generate specflow report 
livingdoc test-assembly "/Users/alexandra.castrillon/Documents/blankfactor-qa/automation-practices/SeleniumXUnit/TestBdd/bin/Debug/net6.0/TestBdd.dll" -t "/Users/alexandra.castrillon/Documents/blankfactor-qa/automation-practices/SeleniumXUnit/TestBdd/bin/Debug/net6.0/TestExecution.json"

allure report
https://github.com/allure-framework/allure2
allure serve /Users/alexandra.castrillon/Documents/blankfactor-qa/automation-practices/SeleniumXUnit/TestBdd/bin/Debug/net6.0/allure-results

retry
xretry package
