# project-euler
Trying to get some of the problems on https://projecteuler.net/ solved.

This project was created with the goal to let people know what code I create looks like, what I focus on and what people whose projects I join can expect.
Important: In order to actually understand how I work, try to have a look at the commit history of this project.

Since this is not about creating an Enterprise Solution, there is not going to be an architecture besides the one naturally emerging from refactorings.
I am probably focusing on DRY and making the usage of extracted methods and classes feel natural.
So whenever you are reading this, feel free to judge how much that was achieved.

What other decisions were made:
 * Performance
   * It should be fast enough for me to allow using GitHub's free 2000 minutes per month ([Link](https://docs.github.com/en/billing/managing-billing-for-github-actions/about-billing-for-github-actions#included-storage-and-minutes))
 * Null safety & argument checking
   * Normally, one would have to make sure the code handles null or negative numbers in a defined (e.g. tested) manner. This project is currently not intended to be used by others or even for anything more than solving the problems. This means there is currently no need for safety checks.