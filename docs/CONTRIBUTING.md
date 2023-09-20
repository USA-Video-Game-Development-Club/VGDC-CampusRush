Contributing
===========

Welcome to the Campus Rush contributing guide! We're exciting to have you participate in the creation of our game, so to make sure you understand how to contribute, let's go over what you'll need to do.

Cloning the Repository
------------
In order to start modifying the game, first you need to clone the project repository. For this tutorial, we will assume you have Github Desktop installed; if you haven't downloaded it already, you can check out our [`GITHUB.md`](GITHUB.md) document to learn how!

1. Open Github Desktop
2. If this is your first time cloning a repository, you can press the `Clone a repository from the Internet` button. Otherwise, you can just go to `File > Clone repository` in the top-left corner (they both take you to the same place).

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/b85d86a1-c7b5-464f-9a06-1eae3b861884)

3. Select the URL tab, copy-paste `https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush.git` into the prompt, and press the blue Clone button.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/e6897ba4-2f0c-4d90-8dfc-ffc47b65110f)

4. You should now see a panel similar to the one in the image below. If so, then you have successfully cloned the repository!

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/e86f830c-4d1f-4259-aa37-21511d016c66)

Open Project in Unity
------------
Now that you've cloned the repository files, you can load the project into Unity and start making changes. If you haven't already downloaded Unity Hub, you can check out our [`UNITY.md`](UNITY.md) document to learn how!

1. Open Unity Hub
2. In the top-right corner, click on the button labeled `Open`.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/3c4e739f-b477-47e9-a29a-1307b140554f)

3. Navigate to the directory where you cloned the repository files. The last directory you open should be the `CampusRush` directory; you'll know you've done this step correctly if it attempts to load the project.
4. You will most likely get a warning message about a missing editor version. This is because we need to download a certain version of the Unity editor in order for the project to compile. Make sure version `2021.3.8f1` is selected, and proceed to install it. You do not need to select any additional platforms to download.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/4bb16b69-6f1c-4d3b-9370-48913a26f484)

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/2e9b6fc8-81f3-4015-a49b-86e57770efe4)

5. Once the download is finished, you should be able to click on the project to open it (assuming it doesn't automatically open). This will open the Unity editor and allow you to make changes to the game!

Forking the Repository
------------
So you've cloned the repository and made some changes to the project in Unity. Awesome! Now it's time to update the repository with the changes you've made. To do this, we will need to create what is known as a "fork" of the repository. 

A fork is essentially just a personal copy of the original repository, which you can modify and test freely to ensure all your changes are correct before merging with the original repository. Let's go over how to create this fork:

1. Open Github Desktop
2. Navigate to the directory where you cloned the repository (if you don't already have it pulled up).
3. Your changes will automatically appear in Github Desktop. Once you've modified at least one file, a prompt should appear near the bottom left of your screen asking if you want to create a fork. Click that.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/99e74c50-7e18-4ca3-a83d-8938007817de)

4. You should be prompted once more to confirm whether you want to create a fork. Proceed to do so.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/bf62da3b-f6f6-419d-a75c-0d0966c53c03)

5. You will now be asked how you plan on using the fork. Select the option titled `To contribute to the parent project`, then press `Continue`.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/51c3cef4-e555-4223-afac-99e235146451)

6. That's it! You've now forked the repository. Now, you can continue to the next section to learn how to create a pull request with your changes.

Pushing Changes to your Fork
------------
Now that you have a fork of the repository, you can push your changes to it. Pushing our changes requires us to first create what's known as a "commit", which is essentially just a saved set of those changes we wish to make. Let's go over how to push our changes:

1. Open Github Desktop and navigate to the project directory.
2. Switch to the branch that you wish to make changes to (note: if you already made changes in the wrong branch, Github Desktop will simply prompt you to bring the changes over to the target branch).

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/02ba3ec1-82ea-4597-bf7c-2f1cbc02a909)

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/96942480-95a0-440d-9a7d-635664643e8e)

3. Confirm you are in the correct branch, then enter a title and summary for your commit detailing what changes are being made (be descriptive!). When you're done, press the blue commit button.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/e5fdb501-c868-48fd-964c-e0f3f989cb9a)

4. Look for a blue `Push origin` button, and click on that.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/eddd4d0e-ad10-4ae8-829f-665ecac5bccb)

5. That's it! Your changes have been pushed to your fork. You can confirm this by viewing the repository on the Github website. 

Creating a Pull Request
------------
Now that we've pushed our changes to our fork, we can create what is known as a "Pull Request" (PR for short). You can think of a pull request sort of like asking for approval to implement your changes to the project. Let's see how to do this:

1. Open Github Desktop and navigate to the project directory.
2. You should see a button labeled `Preview Pull Request` after pushing at least one commit to your fork. Click on it.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/9b182a08-6ea4-4311-a545-3b9a024bef1d)

3. Make sure that you commit to the upstream equivalent of whichever branch you modified (Note: "upstream" is the original repository, and "origin" is your forked repository). Press the blue `Create pull request` button when finished.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/856d90f9-af2e-47e5-9532-b24200c960df)

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/f2e99378-81ad-4775-b5e2-e313c9351f79)

4. You should be taken to a page on the Github website where you can enter a title and summary for your pull request. Enter those details, and then press the green `Create pull request` button.

   ![image](https://github.com/USA-Video-Game-Development-Club/VGDC-CampusRush/assets/115599485/1c00d517-aa9a-45b6-8976-c62748a9abea)

5. That's it! You've created a pull request! Now, other contributors can view and comment on your proposed changes, and a club officer will review the PR before merging the changes. Well done!
