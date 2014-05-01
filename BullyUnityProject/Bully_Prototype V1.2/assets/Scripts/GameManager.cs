using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class GameManager : MonoBehaviour {
	//1 == Daniel 2 == Joy
	public static int selectedChar;
	public static Texture2D mentor;
	public static int LoadStart = 1;
	public static int LoadMap = 4;
	public static int LoadEnd = 8;
	//Holds scene number when going to questions.
	public static int CurrentLocation;
	// 0 No Quest, 1 Quest Pending, 2 Quest Accepted
	public static int QuestFlag = 0;
	// Reference to current quest, -1 means no quest
	public static int CurrentQuest = -1;
	public static string[] Quests;
	public static string[][] Answers;
	public static string[][] Lifeline = new string[3][];
	public static string[][] Response = new string[3][];
	public static bool [][] CorrectAnswer = new bool[3][];
	public static bool [] CompletedQuests = new bool[3];
	public static string[] Bio = new string[2];
	public static AudioClip[] Narration = new AudioClip[3];
	public static AudioClip[][] AudioLifeLine = new AudioClip[3][];
	public static AudioClip[][] AudioResponse = new AudioClip[3][];

	public string xmlPath;
	public Level levelDoc;
	public Quest[] QuestInfo;



	void Awake () {


		xmlPath = Path.Combine (Application.dataPath, "Lake_XML.xml");
		levelDoc = Level.Load(xmlPath);
		QuestInfo = levelDoc.Quests;

		Quests = new string[QuestInfo.Length];
		Answers = new string[QuestInfo.Length][];

		for (int i = 0; i < QuestInfo.Length; i++) {
			Quests[i] = QuestInfo[i].name;
			Debug.Log(Quests[i]);
			Answers[i] = new string[QuestInfo[i].Answers.Length];
			for (int j = 0; j < QuestInfo[i].Answers.Length; j++){
				Answers[i][j] = QuestInfo[i].Answers[j].text;
				Debug.Log ("Answers length is " + QuestInfo[i].Answers.Length);
				Debug.Log(Answers[i][j]);
			}
		}


	}
	// Use this for initialization
	void Start () {
		Debug.Log(Application.loadedLevel);
		if (Application.loadedLevel == 1) {

			/*Answers[0] = new string[4];
			Answers[1] = new string[4];
			Answers[2] = new string[4];*/
			Lifeline[0] = new string[2];
			Lifeline[1] = new string[2];
			Lifeline[2] = new string[2];
			Response[0] = new string[8];
			Response[1] = new string[8];
			Response[2] = new string[8];
			CorrectAnswer[0] = new bool[4];
			CorrectAnswer[1] = new bool[4];
			CorrectAnswer[2] = new bool[4];
			AudioLifeLine[0] = new AudioClip [2];
			AudioLifeLine[1] = new AudioClip [2];
			AudioLifeLine[2] = new AudioClip [2];
			AudioResponse[0] = new AudioClip [8];
			AudioResponse[1] = new AudioClip [8];
			AudioResponse[2] = new AudioClip [8];

			//Quests[0] = "A girl/boy is kayaking at the lake, and suddenly a group of kids surrounded him/her and started splashing water with their paddles. The victim asked them to stop, but they didn't. What will you do?";
			//Quests[1] = "During the camp, you got mentioned on Facebook. There's a girl/boy whose wall has hateful messages all over it. Other people either kept adding on to it or just stood by and did nothing. What action would you take?";
			//Quests[2] = "Two female campers were in a heated argument, others were just gathering around them, watching. The argument soon turned into a fight where the two slapped and pulled each others' hair as you passed by. What will you do?";
			/*Answers[0][0] = "Threaten to send the ones bullying home early";
			Answers[0][1] = "Jump into the water and safe the victim";
			Answers[0][2] = "Yell at the bullies to stop from the side";
			Answers[0][3] = "Tell everyone there is a shark in the water";
			Answers[1][0] = "Report Spam on Facebook.";
			Answers[1][1] = "Comment on the post and ask the bullies to stop.";
			Answers[1][2] = "Come up to the bully in person and confront them. ";
			Answers[1][3] = "Comment on the post and join the crowd.";
			Answers[2][0] = "Calm them down.";
			Answers[2][1] = "Get everyone's attention at the camp to witness the scenario.";
			Answers[2][2] = "Take a video of it and upload it to facebook so everyone can see as evidence.";
			Answers[2][3] = "Jump in to the scene and stop the fight.";*/
			Lifeline[0][0] = "There is more than one right answer, but I think one of the answers is to first think I would try in a scenario like this. I would try talking to the bullies and hope they will respect and listen to people in authority.";
			Lifeline[0][1] = "There are many ways to solve this situation but there is one option that seems to be better than the rest. If I was in this situation I would try to calm the victim and bullies first and foremost and gently talk to them.";
			Lifeline[1][0] = "Cyberbullying is a serious concern that needs to be taken care of. Feeling insecure because they thought nobody will track them down and stop them from bullying can cause serious pain. you can take a stand by confronting them in person and tell them to stop their cyberbullying.";
			Lifeline[1][1] = "Out of the many bullying that has happened, cyberbullying has affected more teenagers. Bullies are not afraid to bully online because they feel safe being anonymous. You can  tell them  in person that it is not right, and ask them to stop.";
			Lifeline[2][0] = "Remember that when people are fighting, their minds are clouded and blocked with anger that would distract them from thinking clearly about their actions.";
			Lifeline[2][1] = "Communication is the key to success. If they can't communicate with each other how would they stop the fight. Find a way to get them to talk their problems out instead of fighting them out.";
			Response[0][0] = "I think there is a better answer for this scenario, nothing good ever comes out of threatening someone.";
			Response[0][1] = "Threatening has never been a good way to solve a problem, maybe there is a better answer for this situation.";
			Response[0][2] = "This will be the next course of action if nothing else seems to stop the bullies, but I think there is another answer that you would try first.";
			Response[0][3] = "If the problem was to continue this would be absolute last resort, but I think there may be a slightly better answer for this situation.";
			Response[0][4] = "Awesome! This is the correct answer for this scenario, but if this fails to make the kids stop splashing, you may have to take another approach. However this is the correct answer and it is always good to ask kids to stop for the first option.";
			Response[0][5] = "Great job! This is the correct answer for this situation, although if this doesn't seem to stop the bullies, there will be another action that will need to take place. For the first course of action politely asking the kids to stop is the best answer.";
			Response[0][6] = "This would be an effective way to solve the problem for sure, but I do think there is a better answer for this scenario than implementing fear.";
			Response[0][7] = "Fear is not a good way to solve a problem, maybe there is a better answer for this situation.";
			Response[1][0] = "I think there is a better answer for this scenario, reporting spam on Facebook will not stop cyberbullying.";
			Response[1][1] = "This is a good action you're taking, but it's too passive. Cyberbullying can go much further even when you reported spam.";
			Response[1][2] = "Asking the bully to stop online might not be the best action that you can take, it might work but there's no guarantee.";
			Response[1][3] = "This action may or may not work. Commenting on the post and asking the bully to stop will definitely not make them stop, the chances are too little.";
			Response[1][4] = "This might be risky, but it is the best option out there. Good job! You made the right move, this shows that you are taking a stand against bullying. You have to approach this very carefully, because a slip of a tongue can make the situation worse. If the problem continues, you should seek higher authorities in the camp.";
			Response[1][5] = "This is a very brave action you're taking, awesome! You took the stand to stop bullying. Telling them to stop in person will be a good reminder for them, that even though they cyberbully someone, they are not anonymous and that should be taken care of in person. if the person makes a big deal out of it, contact a higher authority in the camp site.";
			Response[1][6] = "N/A";
			Response[1][7] = "N/A";
			Response[2][0] = "Good Job! It is really important to people to step back and think carefully about what is going on. Once someone is angry their minds are clouded with anger and they can't see past that. By calming them down you are allowing them to think about their actions before it's too late.";
			Response[2][1] = "Good Job! By calming the two of them down you are able to get into their heads a lot easier. This is a good opportunity to find out what is going on and based on what you gather, you can use that information to stop the fight.";
			Response[2][2] = "By doing this you, there is a high probability that by adding more people to the scenario their judgement about themselves can be changed from others around them. If the others chant them to keep fighting, that is what they would do.";
			Response[2][3] = "Gather people around to witness this event is not a wise decision because rather than teaching people about what needs to stop, you are showing them the fight that is going on which can be influential to future fights to happen.";
			Response[2][4] = "Doing this can demoralize the person that you are filming, once they find out that their video is posted up online it can lower their self esteem and self identity. ";
			Response[2][5] = "Taking a video of the fight and posting it on facebook would just encourage other people to watch the video for the wrong reasons. They would watch it just for the fight and then praise the person who won. The person who won would be prideful and proud of what he did and would continue doing it.";
			Response[2][6] = "This might seem like a good thing to do, but this should only be done if it is the last resort. You first want to calm down before doing anything. By jumping into the fight you might make them think that are you allying up with the other person and they can be threatened by that.";
			Response[2][7] = "This should be done if and only if calming the people down doesn't work. But once you jump in the fight you don't want to make the scenario worse by hurting others or getting hurt yourself. Separate the two of them and stop talking to them.";
			CorrectAnswer[0][0] = false;
			CorrectAnswer[0][1] = false;
			CorrectAnswer[0][2] = true;
			CorrectAnswer[0][3] = false;
			CorrectAnswer[1][0] = false;
			CorrectAnswer[1][1] = false;
			CorrectAnswer[1][2] = false;
			CorrectAnswer[1][3] = true;
			CorrectAnswer[2][0] = true;
			CorrectAnswer[2][1] = false;
			CorrectAnswer[2][2] = false;
			CorrectAnswer[2][3] = false;
			CompletedQuests[0] = false;
			CompletedQuests[1] = false;
			CompletedQuests[2] = false;
			Bio[0] = "Hello! My name is Daniel, I'm a college Freshman majoring in mechanical engineering. I've had several jobs to support myself while helping my parents with their family business, I have to save up for my college funds. I love cars and someday I'd like to be a car designer, I also have a passion for history and am fairly self-motivated. My family and I moved to the US when I was 10,  I grew up in a very tight knit Chinese community ever since. Although dealing with diverse, multi ethnic community might not be my forte, I approach problems from an engineer standpoint which are logical and fact based point of view. With me as your mentor, I'd like to teach you how to view interpersonal difficulties as problems that can be solved as a puzzle, to help you identify your allies and build a peer group with them, lastly to help you develop your self-esteem by discovering hobbies you enjoy and finding people who has similar interest as you. ";
			Bio[1] = "Hello! My name is Joy, I'm a high school Senior. I come from a multi-ethnic family; my father is African American and my mother is of a Northern European heritage. I'm lucky to have both of my parents are college-educated, and live a well-off life.  I can see myself as a popular kid in school, I'm in the cheerleading squad and I participate in sports, although sometimes I still experience discrimination and prejudice because of my racial background. Through my mentorship, I would like to guide you to be able to teach the kids to be more socially skilled, help you develop your self esteem through your own talents and lastly to teach you how to deal with diversity issues (based on my very own very diverse family). ";
			Narration[0] = Resources.Load("Scenario 1/Narrator_Scenario1_Kayak") as AudioClip;
			Narration[1] = Resources.Load("Scenario 2/Narrator_Scenario2_Facebook") as AudioClip;
			Narration[2] = Resources.Load("Scenario 3/Narrator_Scenario3_Femalefight") as AudioClip;
			AudioLifeLine[0][0] = Resources.Load ("Scenario 1/Daniel Wu/DW_Scenario1_Lifeline") as AudioClip;
			AudioLifeLine[0][1] = Resources.Load ("Scenario 1/Joy Stokes/JS_Scenario1_Lifeline") as AudioClip;
			AudioLifeLine[1][0] = Resources.Load ("Scenario 2/Daniel Wu/DW_Scenario2_Lifeline") as AudioClip;
			AudioLifeLine[1][1] = Resources.Load ("Scenario 2/Joy Stokes/JS_Scenario2_Lifeline") as AudioClip;
			AudioLifeLine[2][0] = Resources.Load ("Scenario 3/Daniel Wu/DW_Scenario3_Lifeline") as AudioClip;
			AudioLifeLine[2][1] = Resources.Load ("Scenario 3/Joy Stokes/JS_Scenario3_Lifeline") as AudioClip;
			AudioResponse[0][0] = Resources.Load ("Scenario 1/Daniel Wu/DW_Scenario1_1") as AudioClip;
			AudioResponse[0][1] = Resources.Load ("Scenario 1/Joy Stokes/JS_Scenario1_1") as AudioClip;
			AudioResponse[0][2] = Resources.Load ("Scenario 1/Daniel Wu/DW_Scenario1_2") as AudioClip;
			AudioResponse[0][3] = Resources.Load ("Scenario 1/Joy Stokes/JS_Scenario1_2") as AudioClip;
			AudioResponse[0][4] = Resources.Load ("Scenario 1/Daniel Wu/DW_Scenario1_3") as AudioClip;
			AudioResponse[0][5] = Resources.Load ("Scenario 1/Joy Stokes/JS_Scenario1_3") as AudioClip;
			AudioResponse[0][6] = Resources.Load ("Scenario 1/Daniel Wu/DW_Scenario1_4") as AudioClip;
			AudioResponse[0][7] = Resources.Load ("Scenario 1/Joy Stokes/JS_Scenario1_4") as AudioClip;
			AudioResponse[1][0] = Resources.Load ("Scenario 2/Daniel Wu/DW_Scenario2_1") as AudioClip;
			AudioResponse[1][1] = Resources.Load ("Scenario 2/Joy Stokes/JS_Scenario2_1") as AudioClip;
			AudioResponse[1][2] = Resources.Load ("Scenario 2/Daniel Wu/DW_Scenario2_2") as AudioClip;
			AudioResponse[1][3] = Resources.Load ("Scenario 2/Joy Stokes/JS_Scenario2_2") as AudioClip;
			AudioResponse[1][4] = Resources.Load ("Scenario 2/Daniel Wu/DW_Scenario2_3") as AudioClip;
			AudioResponse[1][5] = Resources.Load ("Scenario 2/Joy Stokes/JS_Scenario2_3") as AudioClip;
			AudioResponse[1][6] = Resources.Load ("Scenario 2/Daniel Wu/DW_Scenario2_4") as AudioClip;
			AudioResponse[1][7] = Resources.Load ("Scenario 2/Joy Stokes/JS_Scenario2_4") as AudioClip;
			AudioResponse[2][0] = Resources.Load ("Scenario 3/Daniel Wu/DW_Scenario3_1") as AudioClip;
			AudioResponse[2][1] = Resources.Load ("Scenario 3/Joy Stokes/JS_Scenario3_1") as AudioClip;
			AudioResponse[2][2] = Resources.Load ("Scenario 3/Daniel Wu/DW_Scenario3_2") as AudioClip;
			AudioResponse[2][3] = Resources.Load ("Scenario 3/Joy Stokes/JS_Scenario3_2") as AudioClip;
			AudioResponse[2][4] = Resources.Load ("Scenario 3/Daniel Wu/DW_Scenario3_3") as AudioClip;
			AudioResponse[2][5] = Resources.Load ("Scenario 3/Joy Stokes/JS_Scenario3_3") as AudioClip;
			AudioResponse[2][6] = Resources.Load ("Scenario 3/Daniel Wu/DW_Scenario3_4") as AudioClip;
			AudioResponse[2][7] = Resources.Load ("Scenario 3/Joy Stokes/JS_Scenario3_4") as AudioClip;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isCompleted(0) && isCompleted (1) && isCompleted (2) && Application.loadedLevel != LoadEnd) {
			Application.LoadLevel (LoadEnd);
		}
	}
	
	int getChar () {
		return selectedChar;
	}
	
	void setChar (int selected) {
		selectedChar = selected;
	}

	public static string GetAnswer (int AnswerNumber) {
		if (CurrentQuest < 0)
			return "Error: No current quest identified, cannot find answer.";
		
		return Answers[CurrentQuest][AnswerNumber-1];
	}

	public static string GetResponse (int AnswerNumber) {
		if (CurrentQuest < 0)
			return "Error: No current quest identified, cannot find response.";

		int temp = (AnswerNumber * 2) - 1;

		if (selectedChar == 1)
			return Response[CurrentQuest][temp - 1];
		else
			return Response[CurrentQuest][temp];
	}

	public static string GetQuest () {
		if (CurrentQuest < 0)
			return "Error: No current quest identified, cannot find quest.";
		return Quests[CurrentQuest];
	}

	public static string GetLifeLine () {
		if (CurrentQuest < 0)
			return "Error: No current quest identified, cannot find lifeline.";
		return Lifeline[CurrentQuest][selectedChar-1];
	}

	public static bool isCorrect (int AnswerNumber) {
		if (CurrentQuest < 0)
			return false;
		return CorrectAnswer [CurrentQuest][AnswerNumber - 1];
	}

	public static bool isCompleted (int QuestID) {
		if (QuestID < 0)
			return false;
		return CompletedQuests[QuestID];
	}

	public static void CompleteQuest (){
		if (CurrentQuest >= 0)
			CompletedQuests[CurrentQuest] = true;
	}
	
		//public static void getScenarios ()
		//{
		//		XMLImporter Scenario = new XMLImporter ("Scene");
		//		List<string[]> questData;
	//
		//		questData = Scenario.run ();
		//}

}
