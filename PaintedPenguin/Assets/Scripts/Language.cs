using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // References
    public GameManager gameManager;
    
    // Main Menu
    public Text GameTitle;
    public string StartButton;
    public string Score;
    public string HelloUsername;

    // Game Over
    public string GameOver;
    public string Replay;
    public string Continue;

    // Score
    public string ScoreUI;

    // Pause
    public string Paused;

    // High Scores
    public string HighScores;

    // Username Input
    public string Name;
    public string OK;
    public string Warning1;
    public string Warning2;
    public Button Flag;

    // Flags
    public Sprite arabic;
    public Sprite bosnian;
    public Sprite bulgarian;
    public Sprite catalan;
    public Sprite cantonese;
    public Sprite mandarin;
    public Sprite taiwanese;
    public Sprite czech;
    public Sprite danish;
    public Sprite dutch;
    public Sprite english;
    public Sprite finnish;
    public Sprite french;
    public Sprite german;
    public Sprite greek;
    public Sprite hebrew;
    public Sprite hindi;
    public Sprite hungarian;
    public Sprite icelandic;
    public Sprite inuit;
    public Sprite italian;
    public Sprite japanese;
    public Sprite korean;
    public Sprite latin;
    public Sprite norwegian;
    public Sprite persian;
    public Sprite polish;
    public Sprite portuguese;
    public Sprite romanian;
    public Sprite russian;
    public Sprite spanish;
    public Sprite swedish;
    public Sprite thai;
    public Sprite turkish;
    public Sprite ukranian;
    public Sprite vietnamese;

    // Languages
    public void English()
    {
        // Main Menu
        GameTitle.text = "Painted Puffin";
        StartButton = "START";
        Score = "SCORE";
        HelloUsername = "Hello, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "REPLAY";
        Continue = "CONTINUE?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSED";

        // High Scores
        HighScores = "HIGH SCORES";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Cannot contain spaces or *.";
        Warning2 = "Must be between 1 and 12 characters.";
        Flag.image.overrideSprite = english;
        gameManager.playerLanguage = "English";
        gameManager.XButtonLanguage();
    }

    public void Arabic()
    {
        // Main Menu
        GameTitle.text = "البفن الملون";
        StartButton = "البدء";
        Score = "درجة عالية";
        HelloUsername = "مرحبا, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "انتهت اللعبة";
        Replay = "عاد عرض المسرحية";
        Continue = "إستأنف؟";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "توقف";

        // High Scores
        HighScores = "درجة عالية";

        // Username Input
        Name = "اسم ...";
        OK = "حسنا";
        Warning1 = "لا يمكن أن تحتوي على مسافات أو *.";
        Warning2 = "يجب أن يكون بين ١ و ١٢ حرفًا.";
        Flag.image.overrideSprite = arabic;
        gameManager.playerLanguage = "Arabic";
        gameManager.XButtonLanguage();
    }

    public void Bosnian()
    {
        // Main Menu
        GameTitle.text = "Painted Puffin";
        StartButton = "START";
        Score = "REZULTATI";
        HelloUsername = "Zdravo, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "KRAJ IGRE";
        Replay = "PONOVO ODIGRATI";
        Continue = "NASTAVITI?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ZASTAO";

        // High Scores
        HighScores = "REZULTATI";

        // Username Input
        Name = "Ime ...";
        OK = "Uredu";
        Warning1 = "Ne može sadržavati razmake ili *.";
        Warning2 = "Mora biti između 1 i 12 znakova.";
        Flag.image.overrideSprite = bosnian;
        gameManager.playerLanguage = "Bosnian";
        gameManager.XButtonLanguage();
    }

    public void Bulgarian()
    {
        // Main Menu
        GameTitle.text = "Пейнтед \nТупик";
        StartButton = "СТАРТ";
        Score = "ВИСОКА ОЦЕНКА";
        HelloUsername = "Здрасти, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "КРАЙ \nНА ИГРАТА";
        Replay = "ПОВТОРЕНИЕ";
        Continue = "ПРОДЪЛЖИТЕ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ПАУЗИРАНА";

        // High Scores
        HighScores = "ВИСОКА ОЦЕНКА";

        // Username Input
        Name = "Име ...";
        OK = "Добре";
        Warning1 = "Не може да съдържа интервали или *.";
        Warning2 = "Трябва да е между 1 и 12 знака.";
        Flag.image.overrideSprite = bulgarian;
        gameManager.playerLanguage = "Bulgarian";
        gameManager.XButtonLanguage();
    }

    public void Catalan()
    {
        // Main Menu
        GameTitle.text = "Puffin Pintat";
        StartButton = "COMENÇAR";
        Score = "PUNTUACIONS";
        HelloUsername = "Hola, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "FI DEL JOC";
        Replay = "REPOSICIÓ";
        Continue = "CONTINUAR?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSAT";

        // High Scores
        HighScores = "PUNTUACIONS";

        // Username Input
        Name = "Nom ...";
        OK = "D'acord";
        Warning1 = "No pot contenir espais o *.";
        Warning2 = "Ha de contenir entre 1 i 12 caràcters.";
        Flag.image.overrideSprite = catalan;
        gameManager.playerLanguage = "Catalan";
        gameManager.XButtonLanguage();
    }

    public void Cantonese()
    {
        // Main Menu
        GameTitle.text = "彩繪松餅";
        StartButton = "初時";
        Score = "高分";
        HelloUsername = "你好, " + gameManager.playerUsername + "！";

        // Game Over
        GameOver = "遊戲結束";
        Replay = "重播";
        Continue = " 繼續？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "暫停";

        // High Scores
        HighScores = "高分";

        // Username Input
        Name = "名字 。。。";
        OK = "仲可以";
        Warning1 = "唔包含空格或“*”。";
        Warning2 = "必須介乎1到12個字符之間。";
        Flag.image.overrideSprite = cantonese;
        gameManager.playerLanguage = "Cantonese";
        gameManager.XButtonLanguage();
    }

    public void Mandarin()
    {
        // Main Menu
        GameTitle.text = "画海雀";
        StartButton = "开始";
        Score = "高分数";
        HelloUsername = "你好, " + gameManager.playerUsername + "！";

        // Game Over
        GameOver = "游戏结束";
        Replay = "重播";
        Continue = " 继续？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "暂停";

        // High Scores
        HighScores = "高分数";

        // Username Input
        Name = "你的名字 。。。";
        OK = "好";
        Warning1 = "不能包含空格或“*”。";
        Warning2 = "必须介于1到12个字符之间。";
        Flag.image.overrideSprite = mandarin;
        gameManager.playerLanguage = "Mandarin";
        gameManager.XButtonLanguage();
    }

    public void Taiwanese()
    {
        // Main Menu
        GameTitle.text = "画海雀";
        StartButton = "开始";
        Score = "高分数";
        HelloUsername = "你好, " + gameManager.playerUsername + "！";

        // Game Over
        GameOver = "游戏结束";
        Replay = "重播";
        Continue = " 继续？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "暂停";

        // High Scores
        HighScores = "高分数";

        // Username Input
        Name = "你的名字 。。。";
        OK = "好";
        Warning1 = "不能包含空格或“*”。";
        Warning2 = "必須介於1到12個字符之間。";
        Flag.image.overrideSprite = taiwanese;
        gameManager.playerLanguage = "Taiwanese";
        gameManager.XButtonLanguage();
    }

    public void Czech()
    {
        // Main Menu
        GameTitle.text = "Malovaný \nPuffin";
        StartButton = "START";
        Score = "SKÓRE";
        HelloUsername = "Ahoj, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "KONEC HRY";
        Replay = "PŘEHRÁT";
        Continue = "POKRAČOVAT?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "POZASTAVENO";

        // High Scores
        HighScores = "VYSOKÉ SKÓRE";

        // Username Input
        Name = "Název ...";
        OK = "Dobře";
        Warning1 = "Nelze obsahovat mezery nebo *.";
        Warning2 = "Musí obsahovat 1 až 12 znaků.";
        Flag.image.overrideSprite = czech;
        gameManager.playerLanguage = "Czech";
        gameManager.XButtonLanguage();
    }

    public void Danish()
    {
        // Main Menu
        GameTitle.text = "Painted \nPuffin";
        StartButton = "START";
        Score = "SCORER";
        HelloUsername = "Hej, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "SPIL IGEN";
        Continue = "FORTSÆTTE?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSET";

        // High Scores
        HighScores = "HØJE SCORER";

        // Username Input
        Name = "Navn ...";
        OK = "OK";
        Warning1 = "Kan ikke indeholde mellemrum eller *.";
        Warning2 = "Skal være mellem 1 og 12 tegn.";
        Flag.image.overrideSprite = danish;
        gameManager.playerLanguage = "Danish";
        gameManager.XButtonLanguage();
    }

    public void Dutch()
    {
        // Main Menu
        GameTitle.text = "Painted \nPuffin";
        StartButton = "START";
        Score = "SCORES";
        HelloUsername = "Hallo, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "SPEEL OPNIEUW";
        Continue = "DOORGAAN?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "GEPAUZEERD";

        // High Scores
        HighScores = "HOGE SCORES";

        // Username Input
        Name = "Naam ...";
        OK = "OK";
        Warning1 = "Kan geen spaties of * bevatten.";
        Warning2 = "Moet tussen 1 en 12 tekens bevatten.";
        Flag.image.overrideSprite = dutch;
        gameManager.playerLanguage = "Dutch";
        gameManager.XButtonLanguage();
    }

    public void Finnish()
    {
        // Main Menu
        GameTitle.text = "Maalattu \nLunni";
        StartButton = "ALKAA";
        Score = "TULOKSET";
        HelloUsername = "Hei, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "PELI LOPPU";
        Replay = "UUSINTA";
        Continue = "JATKAA?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PYSÄYTETTY";

        // High Scores
        HighScores = "HUIPPUPISTEET";

        // Username Input
        Name = "Nimi ...";
        OK = "Hyvä";
        Warning1 = "Ei voi sisältää välilyöntejä tai *.";
        Warning2 = "Täytyy olla 1–12 merkkiä.";
        Flag.image.overrideSprite = finnish;
        gameManager.playerLanguage = "Finnish";
        gameManager.XButtonLanguage();
    }

    public void French()
    {
        // Main Menu
        GameTitle.text = "Macareux Peint";
        StartButton = "DÉBUT";
        Score = "SCORES";
        HelloUsername = "Bonjour, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "JEU TERMINÉ";
        Replay = "REJOUER";
        Continue = "CONTINUER?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "EN PAUSE";

        // High Scores
        HighScores = "SCORES ÉLEVÉS";

        // Username Input
        Name = "Nom ...";
        OK = "D'accord";
        Warning1 = "Ne peut pas contenir d'espaces ou *.";
        Warning2 = "Doit comporter entre 1 et 12 caractères.";
        Flag.image.overrideSprite = french;
        gameManager.playerLanguage = "French";
        gameManager.XButtonLanguage();
    }

    public void German()
    {
        // Main Menu
        GameTitle.text = "Painted Puffin";
        StartButton = "START";
        Score = "PUNKTZAHLEN";
        HelloUsername = "Hallo, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "SPIEL VORBEI";
        Replay = "NEUSTART";
        Continue = "FORTSETZEN?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSIERT";

        // High Scores
        HighScores = "HIGHSCORES";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Darf keine Leerzeichen oder * enthalten.";
        Warning2 = "Muss zwischen 1 und 12 Zeichen enthalten.";
        Flag.image.overrideSprite = german;
        gameManager.playerLanguage = "German";
        gameManager.XButtonLanguage();
    }

    public void Greek()
    {
        // Main Menu
        GameTitle.text = "Παιντεδ \nΠόφφιν";
        StartButton = "ΕΝΑΡΞΗ";
        Score = "ΥΨΗΛΑ ΣΚΟΡ";
        HelloUsername = "Γεια, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "ΤΕΛΟΣ \nΠΑΙΧΝΙΔΙΟΥ";
        Replay = "ΕΠΑΝΑΛΗΨΗ";
        Continue = "ΝΑ ΣΥΝΕΧΙΣΕΙ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ΠΑΥΣΗ";

        // High Scores
        HighScores = "ΥΨΗΛΑ ΣΚΟΡ";

        // Username Input
        Name = "Ονομα ...";
        OK = "Εντάξει";
        Warning1 = "Δεν μπορεί να περιέχει κενά ή *.";
        Warning2 = "Πρέπει να είναι μεταξύ 1 και 12 χαρακτήρων.";
        Flag.image.overrideSprite = greek;
        gameManager.playerLanguage = "Greek";
        gameManager.XButtonLanguage();
    }

    public void Hebrew()
    {
        // Main Menu
        GameTitle.text = "פאפין צבוע";
        StartButton = "התחל";
        Score = "ציונים גבוהים";
        HelloUsername = "שלום, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "סוף משחק";
        Replay = "שידור חוזר";
        Continue = "להמשיך?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "מושהה";

        // High Scores
        HighScores = "ציונים גבוהים";

        // Username Input
        Name = "שם ...";
        OK = "בסדר";
        Warning1 = "לא יכול להכיל רווחים או *.";
        Warning2 = "חייב להיות בין 1 ל 12 אותיות.";
        Flag.image.overrideSprite = hebrew;
        gameManager.playerLanguage = "Hebrew";
        gameManager.XButtonLanguage();
    }

    public void Hindi()
    {
        // Main Menu
        GameTitle.text = "पेंट पफिन";
        StartButton = "शुरु";
        Score = "उच्च स्कोर";
        HelloUsername = "नमस्ते, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "खेल खत्म";
        Replay = "फिर से चालू करें";
        Continue = "जारी रहना?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "रोके गए";

        // High Scores
        HighScores = "उच्च स्कोर";

        // Username Input
        Name = "नाम ...";
        OK = "ठीक";
        Warning1 = "रिक्त स्थान या * नहीं हो सकते।";
        Warning2 = "1 और 12 अक्षरों के बीच होना चाहिए।";
        Flag.image.overrideSprite = hindi;
        gameManager.playerLanguage = "Hindi";
        gameManager.XButtonLanguage();
    }

    public void Hungarian()
    {
        // Main Menu
        GameTitle.text = "FESTETT \nLUNDA";
        StartButton = "START";
        Score = "PONTSZÁMOK";
        HelloUsername = "Szia, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "JÁTÉK VÉGE";
        Replay = "ÚJRAJÁTSZÁS";
        Continue = "FOLYTATNI?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "SZÜNETEL";

        // High Scores
        HighScores = "MAGAS PONTSZÁM";

        // Username Input
        Name = "Név ...";
        OK = "Oké";
        Warning1 = "Nem lehet szóköz vagy *.";
        Warning2 = "1 és 12 karakter között kell lennie.";
        Flag.image.overrideSprite = hungarian;
        gameManager.playerLanguage = "Hungarian";
        gameManager.XButtonLanguage();
    }

    public void Icelandic()
    {
        // Main Menu
        GameTitle.text = "MÁLUÐ \nLUNDI";
        StartButton = "BYRJA";
        Score = "SKORAR";
        HelloUsername = "Halló, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "LEIK LOKIÐ";
        Replay = "ENDURRÆSA";
        Continue = "ÁFRAM?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "GERT HLÉ";

        // High Scores
        HighScores = "HÁR SKORAR";

        // Username Input
        Name = "Nafn ...";
        OK = "OK";
        Warning1 = "Get ekki innihaldið bil eða *.";
        Warning2 = "Verður að vera á milli 1 og 12 stafir.";
        Flag.image.overrideSprite = icelandic;
        gameManager.playerLanguage = "Icelandic";
        gameManager.XButtonLanguage();
    }

    // Inuit

    public void Italian()
    {
        // Main Menu
        GameTitle.text = "PUFFINO \nDIPINTO";
        StartButton = "INIZIO";
        Score = "PUNTEGGI";
        HelloUsername = "Ciao, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "FINE PARTITA";
        Replay = "RIGIOCA";
        Continue = "CONTINUA?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "IN PAUSA";

        // High Scores
        HighScores = "PUNTEGGI";

        // Username Input
        Name = "Nome ...";
        OK = "OK";
        Warning1 = "Non può contenere spazi o *.";
        Warning2 = "Deve contenere da 1 a 12 caratteri.";
        Flag.image.overrideSprite = italian;
        gameManager.playerLanguage = "Italian";
        gameManager.XButtonLanguage();
    }

    public void Japanese()
    {
        // Main Menu
        GameTitle.text = "ツノメドリ\nペイント";
        StartButton = "スタート";
        Score = "スコア";
        HelloUsername = "こんにちは, " + gameManager.playerUsername + "！";

        // Game Over
        GameOver = "ゲーム\nオーバー";
        Replay = "リプレイ";
        Continue = "持続する？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ポーズ中";

        // High Scores
        HighScores = "ハイスコア";

        // Username Input
        Name = "名 ...";
        OK = "オーケー";
        Warning1 = "スペースまたは*を含めることはできません。";
        Warning2 = "1〜12文字にする必要があります。";
        Flag.image.overrideSprite = japanese;
        gameManager.playerLanguage = "Japanese";
        gameManager.XButtonLanguage();
    }

    public void Korean()
    {
        // Main Menu
        GameTitle.text = "그린 퍼핀";
        StartButton = "시작";
        Score = "고득점";
        HelloUsername = "안녕하세요, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "게임 오버";
        Replay = "리플레이";
        Continue = "계속가요?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "일시 중지됨";

        // High Scores
        HighScores = "고득점";

        // Username Input
        Name = "이름 ...";
        OK = "괜찮아";
        Warning1 = "공백이나 *를 포함 할 수 없습니다.";
        Warning2 = "1 ~ 12 자 사이 여야합니다.";
        Flag.image.overrideSprite = korean;
        gameManager.playerLanguage = "Korean";
        gameManager.XButtonLanguage();
    }







    public void Latin()
    {
        // Main Menu
        GameTitle.text = "Painted Puffin";
        StartButton = "Initium";
        Score = "Gradus";
        HelloUsername = "Salve, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "FINIS";
        Replay = "SILEO";
        Continue = " RESUMO?";

        // Score
        ScoreUI = toRoman(gameManager.score);

        // Pause
        Paused = "PAULUM";

        // High Scores
        HighScores = "GRADUS";

        // Username Input
        Name = "Nomen ...";
        OK = "OK";
        Warning1 = "Non habet spatia vel *";
        Warning2 = "XII et I oportet inter ingenia.";
        Flag.image.overrideSprite = latin;
        gameManager.playerLanguage = ",Latin";
        gameManager.XButtonLanguage();
    }

    public string toRoman(int score)
    {
        if (score >= 1000) return "Ⅿ" + toRoman(score - 1000);
        if (score >= 900) return "ⅭⅯ" + toRoman(score - 900);
        if (score >= 500) return "Ⅾ" + toRoman(score - 500);
        if (score >= 400) return "ⅭⅮ" + toRoman(score - 400);
        if (score >= 100) return "Ⅽ" + toRoman(score - 100);
        if (score >= 90) return "ⅩⅭ" + toRoman(score - 90);
        if (score >= 50) return "Ⅼ" + toRoman(score - 50);
        if (score >= 40) return "ⅩⅬ" + toRoman(score - 40);
        if (score >= 10) return "Ⅹ" + toRoman(score - 10);
        if (score >= 9) return "Ⅸ" + toRoman(score - 9);
        if (score >= 5) return "Ⅴ" + toRoman(score - 5);
        if (score >= 4) return "Ⅳ" + toRoman(score - 4);
        if (score >= 1) return "Ⅰ" + toRoman(score - 1);
        return "";
    }
}
