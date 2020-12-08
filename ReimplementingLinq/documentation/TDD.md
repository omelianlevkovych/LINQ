# Introduction 
Unit testing is not only about covering your code to make your cli scream - 'hey dude, you broke something', but also it serves as great documentation of your code.
If unit test passes a scenario with certain params, you can prove that the code works under those params.

## TDD
Test drive development is a methodology when writing code and tests process is reversed and you will start all development with a failig test.
Uncle Bob describes it this way:
- 1. You are not allowed to write any prod code unless you already made a failing unit test pass.
- 2. You are not allowed to write any more of unit test than it is sufficient to fail, and compilation failures are failures.
- 3. You are not allowed any more prod code than is sufficient to pass the one failig unit test.

Red-Green-Refactor!