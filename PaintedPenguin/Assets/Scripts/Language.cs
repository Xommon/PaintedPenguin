using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;
using System;
using System.Globalization;
using System.Linq;

public class Language : MonoBehaviour
{
    // References
    public GameManager gameManager;
    public TMP_FontAsset lgcFont;
    public TMP_FontAsset cjkFont;
    public TMP_FontAsset apuFont;
    public TMP_FontAsset tlbFont;
    public TMP_FontAsset hindiFont;
    public TMP_FontAsset hebrewFont;

    // Language
    public string LanguageName;

    // Main Menu
    public string GameTitle;
    public string StartButton;
    public string Score;
    public string Combo;

    // Credits
    public string CreatedBy;
    public string ArtBy;
    public string IconsBy;

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
    public string numberSeparator;

    // Colour Picker
    public string ColourPickerText;

    // Language Prompt
    public string LanguagePrompt;

    // Username Input
    public string Name;
    public string OK;
    public string Warning1;
    public string Warning2;
    public string Warning3;
    public string Warning4;
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
    public Sprite esperanto;
    public Sprite finnish;
    public Sprite french;
    public Sprite german;
    public Sprite greek;
    public Sprite hebrew;
    public Sprite hindi;
    public Sprite hungarian;
    public Sprite icelandic;
    public Sprite indonesian;
    public Sprite italian;
    public Sprite japanese;
    public Sprite korean;
    public Sprite latin;
    public Sprite mongolian;
    public Sprite norwegian;
    public Sprite persian;
    public Sprite polish;
    public Sprite portuguese;
    public Sprite romanian;
    public Sprite russian;
    public Sprite spanish;
    public Sprite swedish;
    public Sprite tagalog;
    public Sprite thai;
    public Sprite turkish;
    public Sprite ukranian;
    public Sprite vietnamese;

    // Languages
    public void English()
    {
        // Language
        LanguageName = "English (US)";

        // Main Menu
        GameTitle = "Painted Puffin";
        StartButton = "START";
        Score = "SCORE";
        Combo = "combo";

        // Credits


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

        // Colour Picker
        ColourPickerText = "COLOR PICKER";

        // Language Prompt
        LanguagePrompt = "LANGUAGE";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Cannot contain spaces or *.";
        Warning2 = "The name is too long.";
        Warning3 = "Name cannot be blank.";
        Warning4 = "Invalid characters";
        Flag.image.overrideSprite = english;
        gameManager.playerLanguage = "English";
        gameManager.XButtonLanguage();
    } // Verified

    // Languages
    public void EnglishUK()
    {
        // Language
        LanguageName = "English (UK)";

        // Main Menu
        GameTitle = "Painted Puffin";
        StartButton = "START";
        Score = "SCORE";
        Combo = "combo";

        // Credits

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

        // Colour Picker
        ColourPickerText = "COLOUR PICKER";

        // Language Prompt
        LanguagePrompt = "LANGUAGE";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Cannot contain spaces or *.";
        Warning2 = "The name is too long.";
        Warning3 = "Name cannot be blank.";
        Flag.image.overrideSprite = english;
        gameManager.playerLanguage = "English";
        gameManager.XButtonLanguage();
    } // Verified

    public void Arabic()
    {
        // Main Menu
        GameTitle = RTLSupport.FixRTL("رسمت البفن", true, false, false);
        StartButton = Reverse("اﻟﺒﺪء");
        Score = Reverse("ﺩﺭﺟﺔ ﻋﺎﻟﻴﺔ");
        Combo = Arabizer("مزدوج");

        // Game Over
        GameOver = Reverse("ﺍﻧﺘﻬﺖ ﺍﻟﻠﻌﺒﺔ"); // ﺘ
        Replay = Reverse("ﻋﺎﺩ ﻋﺮﺽ ﺍﻟﻤﺴﺮﺣﻴﺔ");
        Continue = Reverse("إﺳﺘﺄﺑﻒ؟");

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = Reverse("ﺗﻮﻗﻒ");

        // High Scores
        HighScores = Reverse("ﺩﺭﺟﺔ ﻋﺎﻟﻴﺔ");

        // Colour Picker
        ColourPickerText = Arabizer("منتقي الألوان");

        // Language Prompt
        LanguagePrompt = Arabizer("لغة");

        // Username Input
        Name = "... " + Reverse("ﺍﺳﻢ");
        OK = Reverse("ﺣﺴﻨﺎ");
        Warning1 = ".* " + Reverse("ﻻ ﻳﻤﻜﻦ ﺃﻥ ﺗﺤﺘﻮﻱ ﻋﻠﻰ ﻣﺴﺎﻓﺎﺕ ﺃﻭ");
        Warning2 = "." + Reverse("ﺍﺳﻢ ﻃﻮﻳﻞ ﺟﺪﺍ");
        Flag.image.overrideSprite = arabic;
        gameManager.playerLanguage = "Arabic";
        gameManager.XButtonLanguage();
    }

    public void Bosnian()
    {
        // Main Menu
        GameTitle = "Ofarbani Puffin";
        StartButton = "START";
        Score = "REZULTATI";
        Combo = "kombo";

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

        // Colour Picker
        ColourPickerText = "Birač boja";

        // Language Prompt
        LanguagePrompt = "JEZIK";

        // Username Input
        Name = "Ime ...";
        OK = "Uredu";
        Warning1 = "Ne može sadržavati razmake ili *.";
        Warning2 = "Ime je predugo.";
        Flag.image.overrideSprite = bosnian;
        gameManager.playerLanguage = "Bosnian";
        gameManager.XButtonLanguage();
    }
    
    public void Bulgarian()
    {
        // Main Menu
        GameTitle = "Пейнтед \nТупик";
        StartButton = "СТАРТ";
        Score = "ВИСОКА ОЦЕНКА";
        Combo = "комбо";

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

        // Colour Picker
        ColourPickerText = "избор на цвят";

        // Language Prompt
        LanguagePrompt = "език";

        // Username Input
        Name = "Име ...";
        OK = "Добре";
        Warning1 = "Не може да съдържа интервали или *.";
        Warning2 = "Името е твърде дълго.";
        Flag.image.overrideSprite = bulgarian;
        gameManager.playerLanguage = "Bulgarian";
        gameManager.XButtonLanguage();
    }

    public void Catalan()
    {
        // Main Menu
        GameTitle = "Fraret Pintat";
        StartButton = "COMENÇAR";
        Score = "PUNTUACIONS";
        Combo = "combo";

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
        Warning2 = "El nom és massa llarg.";
        Flag.image.overrideSprite = catalan;
        gameManager.playerLanguage = "Catalan";
        gameManager.XButtonLanguage();
    }

    public void Cantonese()
    {
        // Main Menu
        GameTitle = "彩繪松餅";
        StartButton = "初時";
        Score = "高分";
        Combo = "二合一";

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
        Warning1 = "唔包含空格或*。";
        Warning2 = "名稱太長。";
        Flag.image.overrideSprite = cantonese;
        gameManager.playerLanguage = "Cantonese";
        gameManager.XButtonLanguage();
    }

    public void Mandarin()
    {
        // Main Menu
        GameTitle = "画海雀";
        StartButton = "开始";
        Score = "高分数";
        Combo = "二合一";

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
        Warning1 = "不能包含空格或*。";
        Warning2 = "名字太长了。";
        Flag.image.overrideSprite = mandarin;
        gameManager.playerLanguage = "Mandarin";
        gameManager.XButtonLanguage();
    } // Verified

    public void Taiwanese()
    {
        // Main Menu
        GameTitle = "画海雀";
        StartButton = "开始";
        Score = "高分数";
        Combo = "二合一";

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
        Warning1 = "不能包含空格或*。";
        Warning2 = "名字太長了。";
        Flag.image.overrideSprite = taiwanese;
        gameManager.playerLanguage = "Taiwanese";
        gameManager.XButtonLanguage();
    }

    public void Czech()
    {
        // Main Menu
        GameTitle = "Malovaný \nPuffin";
        StartButton = "START";
        Score = "SKÓRE";
        Combo = "combo";

        // Game Over
        GameOver = "KONEC HRY";
        Replay = "PŘEHRÁT";
        Continue = "POKRAČOVAT?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "POZASTAVENO";

        // High Scores
        HighScores = "SKÓRE";

        // Username Input
        Name = "Název ...";
        OK = "Dobře";
        Warning1 = "Nelze obsahovat mezery nebo *.";
        Warning2 = "Název je příliš dlouhý.";
        Flag.image.overrideSprite = czech;
        gameManager.playerLanguage = "Czech";
        gameManager.XButtonLanguage();
    }

    public void Danish()
    {
        // Main Menu
        GameTitle = "Malet \nLunde";
        StartButton = "START";
        Score = "SCORER";
        Combo = "combo";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "SPIL IGEN";
        Continue = "FORTSÆTTE?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSET";

        // High Scores
        HighScores = "SCORER";

        // Username Input
        Name = "Navn ...";
        OK = "OK";
        Warning1 = "Kan ikke indeholde mellemrum eller *.";
        Warning2 = "Navnet er for langt.";
        Flag.image.overrideSprite = danish;
        gameManager.playerLanguage = "Danish";
        gameManager.XButtonLanguage();
    }

    public void Dutch() // Verified
    {
        // Main Menu
        GameTitle = "Geschilderde \nPapegaaiduiker";
        StartButton = "START";
        Score = "SCORES";
        Combo = "combo";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "OPNIEUW SPELEN";
        Continue = "DOORGAAN?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "GEPAUZEERD";

        // High Scores
        HighScores = "SCORES";

        // Username Input
        Name = "Naam ...";
        OK = "OK";
        Warning1 = "Kan geen spaties of * bevatten.";
        Warning2 = "De naam is te lang.";
        Flag.image.overrideSprite = dutch;
        gameManager.playerLanguage = "Dutch";
        gameManager.XButtonLanguage();
    }

    public void Esperanto()
    {
        // Main Menu
        GameTitle = "Pentrita \nPufino";
        StartButton = "KOMENCU";
        Score = "SCOROJ";
        Combo = "kombo";

        // Game Over
        GameOver = "LA LUDO \nFINIĜIS";
        Replay = "REPARO";
        Continue = "DAŬRIGU?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAŬZIS";

        // High Scores
        HighScores = "SCOROJ";

        // Username Input
        Name = "Nomo ...";
        OK = "OK";
        Warning1 = "Ne povas enhavi spacojn aŭ *.";
        Warning2 = "La nomo estas tro longa.";
        Flag.image.overrideSprite = esperanto;
        gameManager.playerLanguage = "Esperanto";
        gameManager.XButtonLanguage();
    } // Approximated

    public void Finnish()
    {
        // Main Menu
        GameTitle = "Maalattu \nLunni";
        StartButton = "ALKAA";
        Score = "TULOKSET";
        Combo = "combo";

        // Game Over
        GameOver = "PELI LOPPU";
        Replay = "UUSINTA";
        Continue = "JATKAA?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PYSÄYTETTY";

        // High Scores
        HighScores = "TULOKSET";

        // Username Input
        Name = "Nimi ...";
        OK = "Hyvä";
        Warning1 = "Ei voi sisältää välilyöntejä tai *.";
        Warning2 = "Nimi on liian pitkä.";
        Flag.image.overrideSprite = finnish;
        gameManager.playerLanguage = "Finnish";
        gameManager.XButtonLanguage();
    }

    public void French()
    {
        // Main Menu
        GameTitle = "Macareux Peint";
        StartButton = "DÉBUT";
        Score = "SCORES";
        Combo = "combo";

        // Game Over
        GameOver = "JEU TERMINÉ";
        Replay = "REJOUER";
        Continue = "CONTINUER?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "EN PAUSE";

        // High Scores
        HighScores = "SCORES";

        // Username Input
        Name = "Nom ...";
        OK = "D'accord";
        Warning1 = "Ne peut pas contenir d'espaces ou *.";
        Warning2 = "Le nom est trop long.";
        Flag.image.overrideSprite = french;
        gameManager.playerLanguage = "French";
        gameManager.XButtonLanguage();
    } // Verified

    public void German()
    {
        // Main Menu
        GameTitle = "Painted \nPuffin";
        StartButton = "START";
        Score = "PUNKTE";
        Combo = "combo";

        // Game Over
        GameOver = "SPIEL BEENDET";
        Replay = "NEUSTART";
        Continue = "FORTSETZEN?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSIERT";

        // High Scores
        HighScores = "PUNKTE";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Darf keine Leerzeichen oder * enthalten.";
        Warning2 = "Der Name ist zu lang.";
        Flag.image.overrideSprite = german;
        gameManager.playerLanguage = "German";
        gameManager.XButtonLanguage();
    } // Verified

    public void Greek()
    {
        // Main Menu
        GameTitle = "Παιντεδ \nΠόφφιν";
        StartButton = "ΕΝΑΡΞΗ";
        Score = "ΥΨΗΛΑ ΣΚΟΡ";
        Combo = "διπλό";

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
        Warning2 = "Το όνομα είναι υπερβολικά μεγάλο.";
        Flag.image.overrideSprite = greek;
        gameManager.playerLanguage = "Greek";
        gameManager.XButtonLanguage();
    }

    public void Hebrew()
    {
        // Main Menu
        GameTitle = Reverse("צבוע") + " " + Reverse("פאפין");
        StartButton = Reverse("התחל");
        Score = Reverse("גבוהים") + " " + Reverse("ציונים");
        Combo = Reverse("כפול");

        // Game Over
        GameOver = Reverse("משחק") + " " + Reverse("סוף");
        Replay = Reverse("חוזר") + " " + Reverse("שידור");
        Continue = Reverse("להמשיך?");

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = Reverse("מושהה");

        // High Scores
        HighScores = Reverse("גבוהים") + " " + Reverse("ציונים");

        // Username Input
        Name = Reverse("שם ...");
        OK = Reverse("בסדר");
        Warning1 = ".* " + Reverse("או") + " " + Reverse("רווחים") + " " + Reverse("להכיל") + " " + Reverse("יכול") + " " + Reverse("לא");
        Warning2 = "." + Reverse("מדי") + " " + Reverse("ארוך") + " " + Reverse("השם");
        Flag.image.overrideSprite = hebrew;
        gameManager.playerLanguage = "Hebrew";
        gameManager.XButtonLanguage();
    }

    public void Hindi()
    {
        // Main Menu
        GameTitle = "चित्रित पफिन";
        GameTitle = "चित्रित पफिन";
        StartButton = "शुरु";
        Score = "उच्च स्कोर";
        Combo = "कॉम्बो";

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
        Warning2 = "नाम बहुत लंबा है।";
        Flag.image.overrideSprite = hindi;
        gameManager.playerLanguage = "Hindi";
        gameManager.XButtonLanguage();
    }

    public void Hungarian()
    {
        // Main Menu
        GameTitle = "Festett \nLunda";
        StartButton = "START";
        Score = "PONTSZÁMOK";
        Combo = "combo";

        // Game Over
        GameOver = "JÁTÉK VÉGE";
        Replay = "ÚJRAJÁTSZÁS";
        Continue = "FOLYTATNI?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "SZÜNETEL";

        // High Scores
        HighScores = "PONTSZÁMOK";

        // Username Input
        Name = "Név ...";
        OK = "Oké";
        Warning1 = "Nem lehet szóköz vagy *.";
        Warning2 = "A név túl hosszú.";
        Flag.image.overrideSprite = hungarian;
        gameManager.playerLanguage = "Hungarian";
        gameManager.XButtonLanguage();
    }

    public void Icelandic()
    {
        // Main Menu
        GameTitle = "Máluð \nLunda";
        StartButton = "BYRJA";
        Score = "SKORAR";
        Combo = "tvöfalt";

        // Game Over
        GameOver = "LEIK LOKIÐ";
        Replay = "ENDURRÆSA";
        Continue = "ÁFRAM?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "GERT HLÉ";

        // High Scores
        HighScores = "SKORAR";

        // Username Input
        Name = "Nafn ...";
        OK = "OK";
        Warning1 = "Get ekki innihaldið bil eða *.";
        Warning2 = "Nafnið er of langt.";
        Flag.image.overrideSprite = icelandic;
        gameManager.playerLanguage = "Icelandic";
        gameManager.XButtonLanguage();
    }

    public void Indonesian()
    {
        // Main Menu
        GameTitle = "Puffin \nYang Dicat";
        StartButton = "MULAI";
        Score = "SKOR";
        Combo = "kombo";

        // Game Over
        GameOver = "TAMAT";
        Replay = "ULANGAN";
        Continue = "TERUS?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "DIJEDA";

        // High Scores
        HighScores = "SKOR";

        // Username Input
        Name = "Nama ...";
        OK = "Oke";
        Warning1 = "Tidak dapat memuat spasi atau *.";
        Warning2 = "Namanya terlalu panjang.";
        Flag.image.overrideSprite = indonesian;
        gameManager.playerLanguage = "Indonesian";
        gameManager.XButtonLanguage();
    }

    public void Italian() // Verified
    {
        // Main Menu
        GameTitle = "Painted \nPuffin";
        StartButton = "INIZIO";
        Score = "CLASSIFICA";
        Combo = "combo";

        // Game Over
        GameOver = "FINE PARTITA";
        Replay = "GIOCA DI NUOVO";
        Continue = "CONTINUA?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "IN PAUSA";

        // High Scores
        HighScores = "CLASSIFICA";

        // Username Input
        Name = "Nome ...";
        OK = "OK";
        Warning1 = "Non può contenere spazi o *.";
        Warning2 = "Il nome è troppo lungo";
        Flag.image.overrideSprite = italian;
        gameManager.playerLanguage = "Italian";
        gameManager.XButtonLanguage();
    }

    public void Japanese()
    {
        // Main Menu
        GameTitle = "ツノメドリ\nペイント";
        StartButton = "スタート";
        Score = "スコア";
        Combo = "コンボ";

        // Game Over
        GameOver = "ゲーム\nオーバー";
        Replay = "リプレイ";
        Continue = "持続する？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ポーズ中";

        // High Scores
        HighScores = "スコア";

        // Username Input
        Name = "名 ...";
        OK = "オーケー";
        Warning1 = "スペースまたは*を含めることはできません。";
        Warning2 = "名前が長すぎます。";
        Flag.image.overrideSprite = japanese;
        gameManager.playerLanguage = "Japanese";
        gameManager.XButtonLanguage();
    }

    public void Korean()
    {
        // Main Menu
        GameTitle = "그린 퍼핀";
        StartButton = "시작";
        Score = "고득점";
        Combo = "콤보";

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
        Warning2 = "이름이 너무 깁니다.";
        Flag.image.overrideSprite = korean;
        gameManager.playerLanguage = "Korean";
        gameManager.XButtonLanguage();
    }

    public void Latin()
    {
        // Main Menu
        GameTitle = "Pictis \nMaris Avem";
        StartButton = "INITIUM";
        Score = "GRADUS";
        Combo = "duplus";

        // Game Over
        GameOver = "FINIS";
        Replay = "SILEO";
        Continue = " RESUMO?";

        // Score
        ScoreUI = gameManager.ToRoman(gameManager.score);

        // Pause
        Paused = "PAULUM";

        // High Scores
        HighScores = "GRADUS";

        // Username Input
        Name = "Nomen ...";
        OK = "OK";
        Warning1 = "Non habet spatia vel *";
        Warning2 = "Hoc nomen nimis longum..";
        Flag.image.overrideSprite = latin;
        gameManager.playerLanguage = "Latin";
        gameManager.XButtonLanguage();
    }

    public void Mongolian()
    {
        // Main Menu
        GameTitle = "Пуффиныг \nбудсан";
        StartButton = "СТАРТ";
        Score = "ДЭЭД ОНОО";
        Combo = "комбо";

        // Game Over
        GameOver = "ТОГЛОЛТ \nДУУСЛАА";
        Replay = "ДАХИН АЧААЛЛАХ";
        Continue = "ҮРГЭЛЖЛҮҮЛ";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ТҮР ЗОГСООВ";

        // High Scores
        HighScores = "ДЭЭД ОНОО";

        // Username Input
        Name = "Нэр ...";
        OK = "Тийм Шүү";
        Warning1 = "Хоосон зай буюу * байхгүй.";
        Warning2 = "Нэр хэтэрхий урт байна.";
        Flag.image.overrideSprite = mongolian;
        gameManager.playerLanguage = "Mongolian";
        gameManager.XButtonLanguage();
    }

    public void Norwegian() // Verified
    {
        // Main Menu
        GameTitle = "Malt Lundefugl";
        StartButton = "START";
        Score = "REKORDER";
        Combo = "combo";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "SPILL IGJEN";
        Continue = "FORTSETTE?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "STANSET";

        // High Scores
        HighScores = "REKORDER";

        // Username Input
        Name = "Navn ...";
        OK = "OK";
        Warning1 = "Kan ikke inneholde mellomrom eller *.";
        Warning2 = "Navnet er for langt.";
        Flag.image.overrideSprite = norwegian;
        gameManager.playerLanguage = "Norwegian";
        gameManager.XButtonLanguage();
    }

    public void Persian()
    {
        // Main Menu
        GameTitle = Arabizer("پفین رنگ شده");
        StartButton = Reverse("ﺷﺮﻭﻉ ﻛﻦ");
        Score = Reverse("ﻧﻤﺮﺍﺕ ﺑﺎﻻ");
        Combo = Arabizer("دو برابر");

        // Game Over
        GameOver = Reverse("ﺑﺎﺯﻯ ﺗﻤﺎﻡ ﺷﺩ");
        Replay = Reverse("ﺑﺎﺯﭙﺨﺶ");
        Continue = Reverse("ﺍﺩﺍﻣﻪ ﺩﻫﻴﺪ؟");

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = Reverse("ﻣﺘﻮﻗﻒ\n ﺷﺪﻩ ﺍﺳﺖ");

        // High Scores
        HighScores = Reverse("ﻧﻤﺮﺍﺕ ﺑﺎﻻ");

        // Username Input
        Name = "... " + Reverse("ﻧﺎﻡ");
        OK = Reverse("ﺧﻮﺏ");
        Warning1 = "." + Reverse("ﻫﻴﭻ ﻓﻀﺎ ﻳﺎ * ﻣﺠﺎﺯ ﻧﻴﺴﺖ");
        Warning2 = "." + Reverse("ﻧﺎﻡ ﺧﻴﻠﻰ ﻃﻮﻻﻧﻰ ﺍﺳﺖ");
        Flag.image.overrideSprite = persian;
        gameManager.playerLanguage = "Persian";
        gameManager.XButtonLanguage();
    }

    public void Polish()
    {
        // Main Menu
        GameTitle = "Malowane \nMaskonur";
        StartButton = "POCZĄTEK";
        Score = "WYSOKI WYNIK";
        Combo = "podwójnie";

        // Game Over
        GameOver = "KONIEC GRY";
        Replay = "ZAGRAJ PONOWNIE";
        Continue = "DALEJ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUZA";

        // High Scores
        HighScores = "WYSOKI WYNIK";

        // Username Input
        Name = "Imię ...";
        OK = "Dobrze";
        Warning1 = "Nie może zawierać spacji ani *.";
        Warning2 = "MNazwa jest za długa.";
        Flag.image.overrideSprite = polish;
        gameManager.playerLanguage = "Polish";
        gameManager.XButtonLanguage();
    }

    public void Portuguese()
    {
        // Main Menu
        GameTitle = "Papagaio-do-Mar \nPintado";
        StartButton = "COMEÇAR";
        Score = "PONTUAÇÃO";
        Combo = "combo";

        // Game Over
        GameOver = "FIM DE JOGO";
        Replay = "JOGAR DE NOVO";
        Continue = "CONTINUAR?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "EM PAUSA";

        // High Scores
        HighScores = "PONTUAÇÃO";

        // Username Input
        Name = "Nome ...";
        OK = "OK";
        Warning1 = "Não pode conter espaços ou *.";
        Warning2 = "O nome é muito longo.";
        Flag.image.overrideSprite = portuguese;
        gameManager.playerLanguage = "Portuguese";
        gameManager.XButtonLanguage();
    } // Verified

    public void Romanian()
    {
        // Main Menu
        GameTitle = "Puffin Pictat";
        StartButton = "START";
        Score = "SCOR";
        Combo = "combo";

        // Game Over
        GameOver = "JOC TERMINAT";
        Replay = "JOACA DIN NOU";
        Continue = "CONTINUĂ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "SUSPENDAT";

        // High Scores
        HighScores = "SCOR";

        // Username Input
        Name = "Nume ...";
        OK = "Bine";
        Warning1 = "Nu poate conține spații sau *.";
        Warning2 = "Numele este prea lung.";
        Flag.image.overrideSprite = romanian;
        gameManager.playerLanguage = "Romanian";
        gameManager.XButtonLanguage();
    } // Verified

    public void Russian() // Verified
    {
        // Main Menu
        GameTitle = "Окрашенный \nТупик";
        StartButton = "СТАРТ";
        Score = "РЕКОРДЫ";
        Combo = "комбо";

        // Game Over
        GameOver = "ИГРА ОКОНЧЕНА";
        Replay = "ПОВТОР";
        Continue = "ПРОДОЛЖИТЬ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ПАУЗА";

        // High Scores
        HighScores = "РЕКОРДЫ";

        // Username Input
        Name = "Имя ...";
        OK = "Подтвердить";
        Warning1 = "Не может содержать пробелы или *.";
        Warning2 = "Имя слишком длинное.";
        Flag.image.overrideSprite = russian;
        gameManager.playerLanguage = "Russian";
        gameManager.XButtonLanguage();
    }

    public void Spanish()
    {
        // Main Menu
        GameTitle = "Frailecillo \nPintado";
        StartButton = "COMIENZO";
        Score = "PUNTUACIÓN";
        Combo = "combo";

        // Game Over
        GameOver = "FIN \nDEL JUEGO";
        Replay = "REPETIR";
        Continue = "¿CONTINUAR?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSADO";

        // High Scores
        HighScores = "PUNTUACIÓN";

        // Username Input
        Name = "Nombre ...";
        OK = "Okay";
        Warning1 = "No puede contener espacios o *.";
        Warning2 = "El nombre es muy largo.";
        Flag.image.overrideSprite = spanish;
        gameManager.playerLanguage = "Spanish";
        gameManager.XButtonLanguage();
    }

    public void Swedish()
    {
        // Main Menu
        GameTitle = "Målad \nLunnefågel";
        StartButton = "START";
        Score = "REKORD";
        Combo = "combo";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "SPELA IGEN";
        Continue = "FORTSÄTT?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSAT";

        // High Scores
        HighScores = "REKORD";

        // Username Input
        Name = "Namn ...";
        OK = "Okej";
        Warning1 = "Kan inte innehålla mellanslag eller *.";
        Warning2 = "Namnet är för långt.";
        Flag.image.overrideSprite = swedish;
        gameManager.playerLanguage = "Swedish";
        gameManager.XButtonLanguage();
    }

    public void Tagalog()
    {
        // Main Menu
        GameTitle = "Ipininta Puffin";
        StartButton = "MAGSIMULA";
        Score = "MATAAS NA ISKOR";
        Combo = "combo";

        // Game Over
        GameOver = "TAPOS NA ANG LARO";
        Replay = "SIMULAN MULI";
        Continue = "NILALAMAN?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSTO";

        // High Scores
        HighScores = "MATAAS NA ISKOR";

        // Username Input
        Name = "Pangalan ...";
        OK = "Okey";
        Warning1 = "Hindi ito maaaring maglaman ng mga puwang o *.";
        Warning2 = "Ang pangalan ay masyadong mahaba.";
        Flag.image.overrideSprite = tagalog;
        gameManager.playerLanguage = "Tagalog";
        gameManager.XButtonLanguage();
    }

    public void Thai()
    {
        // Main Menu
        GameTitle = "นกพัฟฟินท์\nทาสี";
        StartButton = "เริ่มต้น";
        Score = "คะแนนสูง";
        Combo = "โบนัส";

        // Game Over
        GameOver = "เกมโอเวอร์";
        Replay = "เล่นอีกรอบ";
        Continue = "เล่นต่อ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "หยุด";

        // High Scores
        HighScores = "คะแนนสูง";

        // Username Input
        Name = "ชื่อ ...";
        OK = "ตกลง";
        Warning1 = "ไม่สามารถมีช่องว่างหรือ*";
        Warning2 = "ชื่อยาวเกินไป";
        Flag.image.overrideSprite = thai;
        gameManager.playerLanguage = "Thai";
        gameManager.XButtonLanguage();
    }

    public void Turkish()
    {
        // Main Menu
        GameTitle = "Boyalı \nMartı";
        StartButton = "BAŞLAYA";
        Score = "YÜKSEK SKOR";
        Combo = "kombo";

        // Game Over
        GameOver = "OYUN BİTTİ";
        Replay = "TEKRAR";
        Continue = "DEVAM ET?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "DURDURULDU";

        // High Scores
        HighScores = "YÜKSEK SKOR";

        // Username Input
        Name = "Isim ...";
        OK = "Tamam";
        Warning1 = "Boşluk içeremez veya *.";
        Warning2 = "İsim çok uzun.";
        Flag.image.overrideSprite = turkish;
        gameManager.playerLanguage = "Turkish";
        gameManager.XButtonLanguage();
    }

    public void Ukranian()
    {
        // Main Menu
        GameTitle = "Пофарбована \nПуффін";
        StartButton = "СТАРТ";
        Score = "ОЦІНКИ";
        Combo = "комбо";

        // Game Over
        GameOver = "ГРА \nЗАВЕРШЕНА";
        Replay = "ПОВТОР";
        Continue = "ПРОДОВЖУВАТИ?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "ПРИЗУПИНЕНО";

        // High Scores
        HighScores = "ОЦІНКИ";

        // Username Input
        Name = "Ім'я ...";
        OK = "Добре";
        Warning1 = "Не може бути пробілів або *.";
        Warning2 = "Ім'я задовге.";
        Flag.image.overrideSprite = ukranian;
        gameManager.playerLanguage = "Ukranian";
        gameManager.XButtonLanguage();
    }

    public void Vietnamese()
    {
        // Main Menu
        GameTitle = "Sơn Puffin";
        StartButton = "BẮT ĐẦU";
        Score = "ĐIỂM CAO";
        Combo = "gấp đôi";

        // Game Over
        GameOver = "TRÒ CHƠI \nKẾT THÚC";
        Replay = "PHÁT LẠI";
        Continue = "TIẾP TỤC?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "TRÒ CHƠI BỊ \nTẠM DỪNG";

        // High Scores
        HighScores = "ĐIỂM CAO";

        // Username Input
        Name = "Tên ...";
        OK = "Được";
        Warning1 = "Không thể chứa dấu cách hoặc *.";
        Warning2 = "Cái tên quá dài.";
        Flag.image.overrideSprite = vietnamese;
        gameManager.playerLanguage = "Vietnamese";
        gameManager.XButtonLanguage();
    }

    public void UpdateFontSettings()
    {
        /// Game Title
        // Font
        if (gameManager.playerLanguage == "Mandarin" || gameManager.playerLanguage == "Taiwanese" || gameManager.playerLanguage == "Cantonese" || gameManager.playerLanguage == "Japanese" || gameManager.playerLanguage == "Korean")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().font = cjkFont;
            gameManager.comboText.GetComponent<TMPro.TextMeshPro>().font = cjkFont;
        }
        else if (gameManager.playerLanguage == "Arabic" || gameManager.playerLanguage == "Persian" || gameManager.playerLanguage == "Urdu")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().font = apuFont;
            gameManager.comboText.GetComponent<TMPro.TextMeshPro>().font = apuFont;
        }
        else if (gameManager.playerLanguage == "Hebrew" || gameManager.playerLanguage == "Yiddish")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().font = hebrewFont;
            gameManager.comboText.GetComponent<TMPro.TextMeshPro>().font = hebrewFont;
        }
        else if (gameManager.playerLanguage == "Thai")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().font = tlbFont;
            gameManager.comboText.GetComponent<TMPro.TextMeshPro>().font = tlbFont;
        }
        else if (gameManager.playerLanguage == "Hindi")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().font = hindiFont;
            gameManager.comboText.GetComponent<TMPro.TextMeshPro>().font = hindiFont;
        }
        else
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().font = lgcFont;
            //gameManager.comboText.GetComponent<TMPro.TextMeshPro>().font = lgcFont;
        }

        // Number Separator
        if (gameManager.playerLanguage == "Arabic" || gameManager.playerLanguage == "Persian")
        {
            numberSeparator = "";
        }
        else if (gameManager.playerLanguage == "French" || gameManager.playerLanguage == "Czech" || gameManager.playerLanguage == "Finnish" || gameManager.playerLanguage == "Hungarian" || gameManager.playerLanguage == "Latin" || gameManager.playerLanguage == "Norwegian" || gameManager.playerLanguage == "Polish" || gameManager.playerLanguage == "Portugese" || gameManager.playerLanguage == "Russian" || gameManager.playerLanguage == "Swedish" || gameManager.playerLanguage == "Ukranian")
        {
            numberSeparator = " ";
        }
        else if (gameManager.playerLanguage == "English" || gameManager.playerLanguage == "Tagalog" || gameManager.playerLanguage == "Taiwanese" || gameManager.playerLanguage == "Mandarin" || gameManager.playerLanguage == "Cantonese" || gameManager.playerLanguage == "Hebrew" || gameManager.playerLanguage == "Yiddish" || gameManager.playerLanguage == "Japanese" || gameManager.playerLanguage == "Korean" || gameManager.playerLanguage == "Urdu" || gameManager.playerLanguage == "Thai")
        {
            numberSeparator = ",";
        }
        else
        {
            numberSeparator = ".";
        }

        // LowerCase
        if (gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().fontStyle != FontStyles.LowerCase)
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().fontStyle = FontStyles.LowerCase;
        }

        // Bold
        //if (gameManager.playerLanguage != "Mandarin" && gameManager.playerLanguage != "Cantonese" && gameManager.playerLanguage != "Taiwanese" && gameManager.playerLanguage != "Korean")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().fontStyle ^= FontStyles.Bold;
        }

        // Spacing
        if (gameManager.playerLanguage == "Hindi")
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().lineSpacing = -20;
        } else
        {
            gameManager.gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().lineSpacing = -30;
        }
    }

    public Font regularLatin;
    public Font regularSimplifiedChinese;

    public string UniversalFontCoder(string entry)
    {
        string codedEntry = entry;

        for (int i = codedEntry.Length - 1; i > -1; i--)
        {
            // Latin
            if (LatinCharacter(entry.Substring(i, 1))) {
                codedEntry = codedEntry.Insert(i, "<font=\"Latin SDF\">");
            } else

            // Cyrillic
            if (CyrillicCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Latin SDF\">");
            }
            else

            // Hebrew
            if (HebrewCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Hebrew SDF\">");
            }
            else

            // Arabic
            if (ArabicCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Arabic SDF\">");
            }
            else

            // Hangul
            if (HangulCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Korean SDF\">");
            }
            else

            // Armenian
            if (ArmenianCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Armenian SDF\">");
            }
            else

            // Bengali
            if (BengaliCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Bengali SDF\">");
            }
            else

            // Japanese
            if (JapaneseCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"Japanese SDF\">");
            }
            else

            // Simplified Chinese
            if (SimplifiedChineseCharacter(entry.Substring(i, 1)))
            {
                codedEntry = codedEntry.Insert(i, "<font=\"SimplifiedChinese SDF\">");
            }
        }

        gameManager.gameTitleText.text = codedEntry;
        return codedEntry;
    }

    public bool LatinCharacter(string letter)
    {
        string charSet = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz`1234567890-=~!@#$%^&*()_+[{]}\\|;:'\",<.>/?¡¢£¤¥¦§¨©ª«¬®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþÿĀāĂăĄąĆćĈĉĊċČčĎďĐđĒēĔĕĖėĘęĚěĜĝĞğĠġĢģĤĥĦħĨĩĪīĬĭĮįİıĲĳĴĵĶķĸĹĺĻļĽľĿŀŁłŃńŅņŇňŉŊŋŌōŎŏŐőŒœŔŕŖŗŘřŚśŜŝŞşŠšŢţŤťŦŧŨũŪūŬŭŮůŰűŲųŴŵŶŷŸŹźŻżŽžſƀƁƂƃƄƅƆƇƈƉƊƋƌƍƎƏƐƑƒƓƔƕƖƗƘƙƚƛƜƝƞƟƠơƢƣƤƥƦƧƨƩƪƫƬƭƮƯưƱƲƳƴƵƶƷƸƹƺƻƼƽƾƿǀǁǂǃǄǅǆǇǈǉǊǋǌǍǎǏǐǑǒǓǔǕǖǗǘǙǚǛǜǝǞǟǠǡǢǣǤǥǦǧǨǩǪǫǬǭǮǯǰǱǲǳǴǵǶǷǸǹǺǻǼǽǾǿȀȁȂȃȄȅȆȇȈȉȊȋȌȍȎȏȐȑȒȓȔȕȖȗȘșȚțȜȝȞȟȠȡȢȣȤȥȦȧȨȩȪȫȬȭȮȯȰȱȲȳȴȵȶȷȸȹȺȻȼȽȾȿɀɁɂɃɄɅɆɇɈɉɊɋɌɍɎɏ";

        for (int i = 0; i < charSet.Length - 1; i++) {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool CyrillicCharacter(string letter)
    {
        string charSet = "ЀЁЂЃЄЅІЇЈЉЊЋЌЍЎЏАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюяѐёђѓєѕіїјљњћќѝўџѠѡѢѣѤѥѦѧѨѩѪѫѬѭѮѯѰѱѲѳѴѵѶѷѸѹѺѻѼѽѾѿҀҁ҂҃҄҅҆҇҈҉ҊҋҌҍҎҏҐґҒғҔҕҖҗҘҙҚқҜҝҞҟҠҡҢңҤҥҦҧҨҩҪҫҬҭҮүҰұҲҳҴҵҶҷҸҹҺһҼҽҾҿӀӁӂӃӄӅӆӇӈӉӊӋӌӍӎӏӐӑӒӓӔӕӖӗӘәӚӛӜӝӞӟӠӡӢӣӤӥӦӧӨөӪӫӬӭӮӯӰӱӲӳӴӵӶӷӸӹӺӻӼӽӾӿ҂2҃3҄҅5҆6҇7҈҉ҊҋҌҍҎҏҐґҒ2ғ3Ҕҕ5Җ6җ7ҘҙҚқҜҝҞҟҠҡҢ2ң3Ҥҥ5Ҧ6ҧ7ҨҩҪҫҬҭҮүҰұҲ2ҳ3Ҵҵ5Ҷ6ҷ7ҸҹҺһҼҽҾҿӀӁӂ2Ӄ3ӄӅ5ӆ6Ӈ7ӈӉӊӋӌӍӎӏӐӑӒ2ӓ3Ӕӕ5Ӗ6ӗ7ӘәӚӛӜӝӞӟӠӡӢ2ӣ3Ӥӥ5Ӧ6ӧ7ӨөӪӫӬӭӮӯӰӱӲ2ӳ3Ӵӵ5Ӷ6ӷ7ӸӹӺӻӼӽӾӿ";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool HebrewCharacter(string letter)
    {
        string charSet = "׫׬׭׮ׯװױײ׳״׵׶׷׸׹׺׻׼׽׾׿֐ְֱֲֳִֵֶַָֹֺֻּֽ֑֖֛֢֣֤֥֦֧֪֚֭֮֒֓֔֕֗֘֙֜֝֞֟֠֡֨֩֫֬֯־ֿ׀ׁׂ׃ׅׄ׆ׇ׈׉׊׋׌׍׎׏אבגדהוזחטיךכלםמןנסעףפץצקרשת";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool ArabicCharacter(string letter)
    {
        string charSet = "؀؁؂؃؄؅؆؇؈؉؊؋،؍؎؏ؘؙؚؐؑؒؓؔؕؖؗ؛؜؝؞؟ؠءآأؤإئابةتثجحخدذرزسشصضطظعغػؼؽؾؿـفقكلمنهوىيًٌٍَُِّْٕٖٜٟٓٔٗ٘ٙٚٛٝٞ٠١٢٣٤٥٦٧٨٩٪٫٬٭ٮٯٰٱٲٳٴٵٶٷٸٹٺٻټٽپٿڀځڂڃڄڅچڇڈډڊڋڌڍڎڏڐڑڒړڔڕږڗژڙښڛڜڝڞڟڠڡڢڣڤڥڦڧڨکڪګڬڭڮگڰڱڲڳڴڵڶڷڸڹںڻڼڽھڿۀہۂۃۄۅۆۇۈۉۊۋیۍێۏېۑےۓ۔ەۖۗۘۙۚۛۜ۝۞ۣ۟۠ۡۢۤۥۦۧۨ۩۪ۭ۫۬ۮۯ۰۱۲۳۴۵۶۷۸۹ۺۻۼ۽۾ۿ";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool ArabicLetter(string letter)
    {
        string charSet = "؀ؘؙؚؔؕؖؗ؜ؠآأؤإئابةتثجحخدذرزسشصضطظعغػؼؽؾؿـفقكلمنهوىيًٌٍَُِّْٕٖٜٟٓٔٗ٘ٙٚٛٝٞٮٯٰٱٲٳٴٵٶٷٸٹٺٻټٽپٿڀځڂڃڄڅچڇڈډڊڋڌڍڎڏڐڑڒړڔڕږڗژڙښڛڜڝڞڟڠڡڢڣڤڥڦڧڨکڪګڬڭڮگڰڱڲڳڴڵڶڷڸڹںڻڼڽھڿۀہۂۃۄۅۆۇۈۉۊۋیۍێۏېۑےۓ۔ەۣۖۗۘۙۚۛۜ۠ۡۢۤۥۦۭۧۨ۬ۮۯۺۻۼ۽۾ۿ";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool HangulCharacter(string letter)
    {
        string charSet = "가각갂갃간갅갆갇갈갉갊갋갌갍갎갏감갑값갓갔강갖갗갘같갚갛개객갞갟갠갡갢갣갤갥갦갧갨갩갪갫갬갭갮갯갰갱갲갳갴갵갶갷갸갹갺갻갼갽갾갿걀걁걂걃걄걅걆걇걈걉걊걋걌걍걎걏걐걑걒걓걔걕걖걗걘걙걚걛걜걝걞걟걠걡걢걣걤걥걦걧걨걩걪걫걬걭걮걯거걱걲걳건걵걶걷걸걹걺걻걼걽걾걿검겁겂것겄겅겆겇겈겉겊겋게겍겎겏겐겑겒겓겔겕겖겗겘겙겚겛겜겝겞겟겠겡겢겣겤겥겦겧겨격겪겫견겭겮겯결겱겲겳겴겵겶겷겸겹겺겻겼경겾겿곀곁곂곃계곅곆곇곈곉곊곋곌곍곎곏곐곑곒곓곔곕곖곗곘곙곚곛곜곝곞곟고곡곢곣곤곥곦곧골곩곪곫곬곭곮곯곰곱곲곳곴공곶곷곸곹곺곻과곽곾곿관괁괂괃괄괅괆괇괈괉괊괋괌괍괎괏괐광괒괓괔괕괖괗괘괙괚괛괜괝괞괟괠괡괢괣괤괥괦괧괨괩괪괫괬괭괮괯괰괱괲괳괴괵괶괷괸괹괺괻괼괽괾괿굀굁굂굃굄굅굆굇굈굉굊굋굌굍굎굏교굑굒굓굔굕굖굗굘굙굚굛굜굝굞굟굠굡굢굣굤굥굦굧굨굩굪굫구국굮굯군굱굲굳굴굵굶굷굸굹굺굻굼굽굾굿궀궁궂궃궄궅궆궇궈궉궊궋권궍궎궏궐궑궒궓궔궕궖궗궘궙궚궛궜궝궞궟궠궡궢궣궤궥궦궧궨궩궪궫궬궭궮궯궰궱궲궳궴궵궶궷궸궹궺궻궼궽궾궿귀귁귂귃귄귅귆귇귈귉귊귋귌귍귎귏귐귑귒귓귔귕귖귗귘귙귚귛규귝귞귟균귡귢귣귤귥귦귧귨귩귪귫귬귭귮귯귰귱귲귳귴귵귶귷그극귺귻근귽귾귿글긁긂긃긄긅긆긇금급긊긋긌긍긎긏긐긑긒긓긔긕긖긗긘긙긚긛긜긝긞긟긠긡긢긣긤긥긦긧긨긩긪긫긬긭긮긯기긱긲긳긴긵긶긷길긹긺긻긼긽긾긿김깁깂깃깄깅깆깇깈깉깊깋까깍깎깏깐깑깒깓깔깕깖깗깘깙깚깛깜깝깞깟깠깡깢깣깤깥깦깧깨깩깪깫깬깭깮깯깰깱깲깳깴깵깶깷깸깹깺깻깼깽깾깿꺀꺁꺂꺃꺄꺅꺆꺇꺈꺉꺊꺋꺌꺍꺎꺏꺐꺑꺒꺓꺔꺕꺖꺗꺘꺙꺚꺛꺜꺝꺞꺟꺠꺡꺢꺣꺤꺥꺦꺧꺨꺩꺪꺫꺬꺭꺮꺯꺰꺱꺲꺳꺴꺵꺶꺷꺸꺹꺺꺻꺼꺽꺾꺿껀껁껂껃껄껅껆껇껈껉껊껋껌껍껎껏껐껑껒껓껔껕껖껗께껙껚껛껜껝껞껟껠껡껢껣껤껥껦껧껨껩껪껫껬껭껮껯껰껱껲껳껴껵껶껷껸껹껺껻껼껽껾껿꼀꼁꼂꼃꼄꼅꼆꼇꼈꼉꼊꼋꼌꼍꼎꼏꼐꼑꼒꼓꼔꼕꼖꼗꼘꼙꼚꼛꼜꼝꼞꼟꼠꼡꼢꼣꼤꼥꼦꼧꼨꼩꼪꼫꼬꼭꼮꼯꼰꼱꼲꼳꼴꼵꼶꼷꼸꼹꼺꼻꼼꼽꼾꼿꽀꽁꽂꽃꽄꽅꽆꽇꽈꽉꽊꽋꽌꽍꽎꽏꽐꽑꽒꽓꽔꽕꽖꽗꽘꽙꽚꽛꽜꽝꽞꽟꽠꽡꽢꽣꽤꽥꽦꽧꽨꽩꽪꽫꽬꽭꽮꽯꽰꽱꽲꽳꽴꽵꽶꽷꽸꽹꽺꽻꽼꽽꽾꽿꾀꾁꾂꾃꾄꾅꾆꾇꾈꾉꾊꾋꾌꾍꾎꾏꾐꾑꾒꾓꾔꾕꾖꾗꾘꾙꾚꾛꾜꾝꾞꾟꾠꾡꾢꾣꾤꾥꾦꾧꾨꾩꾪꾫꾬꾭꾮꾯꾰꾱꾲꾳꾴꾵꾶꾷꾸꾹꾺꾻꾼꾽꾾꾿꿀꿁꿂꿃꿄꿅꿆꿇꿈꿉꿊꿋꿌꿍꿎꿏꿐꿑꿒꿓꿔꿕꿖꿗꿘꿙꿚꿛꿜꿝꿞꿟꿠꿡꿢꿣꿤꿥꿦꿧꿨꿩꿪꿫꿬꿭꿮꿯꿰꿱꿲꿳꿴꿵꿶꿷꿸꿹꿺꿻꿼꿽꿾꿿뀀뀁뀂뀃뀄뀅뀆뀇뀈뀉뀊뀋뀌뀍뀎뀏뀐뀑뀒뀓뀔뀕뀖뀗뀘뀙뀚뀛뀜뀝뀞뀟뀠뀡뀢뀣뀤뀥뀦뀧뀨뀩뀪뀫뀬뀭뀮뀯뀰뀱뀲뀳뀴뀵뀶뀷뀸뀹뀺뀻뀼뀽뀾뀿끀끁끂끃끄끅끆끇끈끉끊끋끌끍끎끏끐끑끒끓끔끕끖끗끘끙끚끛끜끝끞끟끠끡끢끣끤끥끦끧끨끩끪끫끬끭끮끯끰끱끲끳끴끵끶끷끸끹끺끻끼끽끾끿낀낁낂낃낄낅낆낇낈낉낊낋낌낍낎낏낐낑낒낓낔낕낖낗나낙낚낛난낝낞낟날낡낢낣낤낥낦낧남납낪낫났낭낮낯낰낱낲낳내낵낶낷낸낹낺낻낼낽낾낿냀냁냂냃냄냅냆냇냈냉냊냋냌냍냎냏냐냑냒냓냔냕냖냗냘냙냚냛냜냝냞냟냠냡냢냣냤냥냦냧냨냩냪냫냬냭냮냯냰냱냲냳냴냵냶냷냸냹냺냻냼냽냾냿넀넁넂넃넄넅넆넇너넉넊넋넌넍넎넏널넑넒넓넔넕넖넗넘넙넚넛넜넝넞넟넠넡넢넣네넥넦넧넨넩넪넫넬넭넮넯넰넱넲넳넴넵넶넷넸넹넺넻넼넽넾넿녀녁녂녃년녅녆녇녈녉녊녋녌녍녎녏념녑녒녓녔녕녖녗녘녙녚녛녜녝녞녟녠녡녢녣녤녥녦녧녨녩녪녫녬녭녮녯녰녱녲녳녴녵녶녷노녹녺녻논녽녾녿놀놁놂놃놄놅놆놇놈놉놊놋놌농놎놏놐놑높놓놔놕놖놗놘놙놚놛놜놝놞놟놠놡놢놣놤놥놦놧놨놩놪놫놬놭놮놯놰놱놲놳놴놵놶놷놸놹놺놻놼놽놾놿뇀뇁뇂뇃뇄뇅뇆뇇뇈뇉뇊뇋뇌뇍뇎뇏뇐뇑뇒뇓뇔뇕뇖뇗뇘뇙뇚뇛뇜뇝뇞뇟뇠뇡뇢뇣뇤뇥뇦뇧뇨뇩뇪뇫뇬뇭뇮뇯뇰뇱뇲뇳뇴뇵뇶뇷뇸뇹뇺뇻뇼뇽뇾뇿눀눁눂눃누눅눆눇눈눉눊눋눌눍눎눏눐눑눒눓눔눕눖눗눘눙눚눛눜눝눞눟눠눡눢눣눤눥눦눧눨눩눪눫눬눭눮눯눰눱눲눳눴눵눶눷눸눹눺눻눼눽눾눿뉀뉁뉂뉃뉄뉅뉆뉇뉈뉉뉊뉋뉌뉍뉎뉏뉐뉑뉒뉓뉔뉕뉖뉗뉘뉙뉚뉛뉜뉝뉞뉟뉠뉡뉢뉣뉤뉥뉦뉧뉨뉩뉪뉫뉬뉭뉮뉯뉰뉱뉲뉳뉴뉵뉶뉷뉸뉹뉺뉻뉼뉽뉾뉿늀늁늂늃늄늅늆늇늈늉늊늋늌늍늎늏느늑늒늓는늕늖늗늘늙늚늛늜늝늞늟늠늡늢늣늤능늦늧늨늩늪늫늬늭늮늯늰늱늲늳늴늵늶늷늸늹늺늻늼늽늾늿닀닁닂닃닄닅닆닇니닉닊닋닌닍닎닏닐닑닒닓닔닕닖닗님닙닚닛닜닝닞닟닠닡닢닣다닥닦닧단닩닪닫달닭닮닯닰닱닲닳담답닶닷닸당닺닻닼닽닾닿대댁댂댃댄댅댆댇댈댉댊댋댌댍댎댏댐댑댒댓댔댕댖댗댘댙댚댛댜댝댞댟댠댡댢댣댤댥댦댧댨댩댪댫댬댭댮댯댰댱댲댳댴댵댶댷댸댹댺댻댼댽댾댿덀덁덂덃덄덅덆덇덈덉덊덋덌덍덎덏덐덑덒덓더덕덖덗던덙덚덛덜덝덞덟덠덡덢덣덤덥덦덧덨덩덪덫덬덭덮덯데덱덲덳덴덵덶덷델덹덺덻덼덽덾덿뎀뎁뎂뎃뎄뎅뎆뎇뎈뎉뎊뎋뎌뎍뎎뎏뎐뎑뎒뎓뎔뎕뎖뎗뎘뎙뎚뎛뎜뎝뎞뎟뎠뎡뎢뎣뎤뎥뎦뎧뎨뎩뎪뎫뎬뎭뎮뎯뎰뎱뎲뎳뎴뎵뎶뎷뎸뎹뎺뎻뎼뎽뎾뎿돀돁돂돃도독돆돇돈돉돊돋돌돍돎돏돐돑돒돓돔돕돖돗돘동돚돛돜돝돞돟돠돡돢돣돤돥돦돧돨돩돪돫돬돭돮돯돰돱돲돳돴돵돶돷돸돹돺돻돼돽돾돿됀됁됂됃됄됅됆됇됈됉됊됋됌됍됎됏됐됑됒됓됔됕됖됗되됙됚됛된됝됞됟될됡됢됣됤됥됦됧됨됩됪됫됬됭됮됯됰됱됲됳됴됵됶됷됸됹됺됻됼됽됾됿둀둁둂둃둄둅둆둇둈둉둊둋둌둍둎둏두둑둒둓둔둕둖둗둘둙둚둛둜둝둞둟둠둡둢둣둤둥둦둧둨둩둪둫둬둭둮둯둰둱둲둳둴둵둶둷둸둹둺둻둼둽둾둿뒀뒁뒂뒃뒄뒅뒆뒇뒈뒉뒊뒋뒌뒍뒎뒏뒐뒑뒒뒓뒔뒕뒖뒗뒘뒙뒚뒛뒜뒝뒞뒟뒠뒡뒢뒣뒤뒥뒦뒧뒨뒩뒪뒫뒬뒭뒮뒯뒰뒱뒲뒳뒴뒵뒶뒷뒸뒹뒺뒻뒼뒽뒾뒿듀듁듂듃듄듅듆듇듈듉듊듋듌듍듎듏듐듑듒듓듔듕듖듗듘듙듚듛드득듞듟든듡듢듣들듥듦듧듨듩듪듫듬듭듮듯듰등듲듳듴듵듶듷듸듹듺듻듼듽듾듿딀딁딂딃딄딅딆딇딈딉딊딋딌딍딎딏딐딑딒딓디딕딖딗딘딙딚딛딜딝딞딟딠딡딢딣딤딥딦딧딨딩딪딫딬딭딮딯따딱딲딳딴딵딶딷딸딹딺딻딼딽딾딿땀땁땂땃땄땅땆땇땈땉땊땋때땍땎땏땐땑땒땓땔땕땖땗땘땙땚땛땜땝땞땟땠땡땢땣땤땥땦땧땨땩땪땫땬땭땮땯땰땱땲땳땴땵땶땷땸땹땺땻땼땽땾땿떀떁떂떃떄떅떆떇떈떉떊떋떌떍떎떏떐떑떒떓떔떕떖떗떘떙떚떛떜떝떞떟떠떡떢떣떤떥떦떧떨떩떪떫떬떭떮떯떰떱떲떳떴떵떶떷떸떹떺떻떼떽떾떿뗀뗁뗂뗃뗄뗅뗆뗇뗈뗉뗊뗋뗌뗍뗎뗏뗐뗑뗒뗓뗔뗕뗖뗗뗘뗙뗚뗛뗜뗝뗞뗟뗠뗡뗢뗣뗤뗥뗦뗧뗨뗩뗪뗫뗬뗭뗮뗯뗰뗱뗲뗳뗴뗵뗶뗷뗸뗹뗺뗻뗼뗽뗾뗿똀똁똂똃똄똅똆똇똈똉똊똋똌똍똎똏또똑똒똓똔똕똖똗똘똙똚똛똜똝똞똟똠똡똢똣똤똥똦똧똨똩똪똫똬똭똮똯똰똱똲똳똴똵똶똷똸똹똺똻똼똽똾똿뙀뙁뙂뙃뙄뙅뙆뙇뙈뙉뙊뙋뙌뙍뙎뙏뙐뙑뙒뙓뙔뙕뙖뙗뙘뙙뙚뙛뙜뙝뙞뙟뙠뙡뙢뙣뙤뙥뙦뙧뙨뙩뙪뙫뙬뙭뙮뙯뙰뙱뙲뙳뙴뙵뙶뙷뙸뙹뙺뙻뙼뙽뙾뙿뚀뚁뚂뚃뚄뚅뚆뚇뚈뚉뚊뚋뚌뚍뚎뚏뚐뚑뚒뚓뚔뚕뚖뚗뚘뚙뚚뚛뚜뚝뚞뚟뚠뚡뚢뚣뚤뚥뚦뚧뚨뚩뚪뚫뚬뚭뚮뚯뚰뚱뚲뚳뚴뚵뚶뚷뚸뚹뚺뚻뚼뚽뚾뚿뛀뛁뛂뛃뛄뛅뛆뛇뛈뛉뛊뛋뛌뛍뛎뛏뛐뛑뛒뛓뛔뛕뛖뛗뛘뛙뛚뛛뛜뛝뛞뛟뛠뛡뛢뛣뛤뛥뛦뛧뛨뛩뛪뛫뛬뛭뛮뛯뛰뛱뛲뛳뛴뛵뛶뛷뛸뛹뛺뛻뛼뛽뛾뛿뜀뜁뜂뜃뜄뜅뜆뜇뜈뜉뜊뜋뜌뜍뜎뜏뜐뜑뜒뜓뜔뜕뜖뜗뜘뜙뜚뜛뜜뜝뜞뜟뜠뜡뜢뜣뜤뜥뜦뜧뜨뜩뜪뜫뜬뜭뜮뜯뜰뜱뜲뜳뜴뜵뜶뜷뜸뜹뜺뜻뜼뜽뜾뜿띀띁띂띃띄띅띆띇띈띉띊띋띌띍띎띏띐띑띒띓띔띕띖띗띘띙띚띛띜띝띞띟띠띡띢띣띤띥띦띧띨띩띪띫띬띭띮띯띰띱띲띳띴띵띶띷띸띹띺띻라락띾띿란랁랂랃랄랅랆랇랈랉랊랋람랍랎랏랐랑랒랓랔랕랖랗래랙랚랛랜랝랞랟랠랡랢랣랤랥랦랧램랩랪랫랬랭랮랯랰랱랲랳랴략랶랷랸랹랺랻랼랽랾랿럀럁럂럃럄럅럆럇럈량럊럋럌럍럎럏럐럑럒럓럔럕럖럗럘럙럚럛럜럝럞럟럠럡럢럣럤럥럦럧럨럩럪럫러럭럮럯런럱럲럳럴럵럶럷럸럹럺럻럼럽럾럿렀렁렂렃렄렅렆렇레렉렊렋렌렍렎렏렐렑렒렓렔렕렖렗렘렙렚렛렜렝렞렟렠렡렢렣려력렦렧련렩렪렫렬렭렮렯렰렱렲렳렴렵렶렷렸령렺렻렼렽렾렿례롁롂롃롄롅롆롇롈롉롊롋롌롍롎롏롐롑롒롓롔롕롖롗롘롙롚롛로록롞롟론롡롢롣롤롥롦롧롨롩롪롫롬롭롮롯롰롱롲롳롴롵롶롷롸롹롺롻롼롽롾롿뢀뢁뢂뢃뢄뢅뢆뢇뢈뢉뢊뢋뢌뢍뢎뢏뢐뢑뢒뢓뢔뢕뢖뢗뢘뢙뢚뢛뢜뢝뢞뢟뢠뢡뢢뢣뢤뢥뢦뢧뢨뢩뢪뢫뢬뢭뢮뢯뢰뢱뢲뢳뢴뢵뢶뢷뢸뢹뢺뢻뢼뢽뢾뢿룀룁룂룃룄룅룆룇룈룉룊룋료룍룎룏룐룑룒룓룔룕룖룗룘룙룚룛룜룝룞룟룠룡룢룣룤룥룦룧루룩룪룫룬룭룮룯룰룱룲룳룴룵룶룷룸룹룺룻룼룽룾룿뤀뤁뤂뤃뤄뤅뤆뤇뤈뤉뤊뤋뤌뤍뤎뤏뤐뤑뤒뤓뤔뤕뤖뤗뤘뤙뤚뤛뤜뤝뤞뤟뤠뤡뤢뤣뤤뤥뤦뤧뤨뤩뤪뤫뤬뤭뤮뤯뤰뤱뤲뤳뤴뤵뤶뤷뤸뤹뤺뤻뤼뤽뤾뤿륀륁륂륃륄륅륆륇륈륉륊륋륌륍륎륏륐륑륒륓륔륕륖륗류륙륚륛륜륝륞륟률륡륢륣륤륥륦륧륨륩륪륫륬륭륮륯륰륱륲륳르륵륶륷른륹륺륻를륽륾륿릀릁릂릃름릅릆릇릈릉릊릋릌릍릎릏릐릑릒릓릔릕릖릗릘릙릚릛릜릝릞릟릠릡릢릣릤릥릦릧릨릩릪릫리릭릮릯린릱릲릳릴릵릶릷릸릹릺릻림립릾릿맀링맂맃맄맅맆맇마막맊맋만맍많맏말맑맒맓맔맕맖맗맘맙맚맛맜망맞맟맠맡맢맣매맥맦맧맨맩맪맫맬맭맮맯맰맱맲맳맴맵맶맷맸맹맺맻맼맽맾맿먀먁먂먃먄먅먆먇먈먉먊먋먌먍먎먏먐먑먒먓먔먕먖먗먘먙먚먛먜먝먞먟먠먡먢먣먤먥먦먧먨먩먪먫먬먭먮먯먰먱먲먳먴먵먶먷머먹먺먻먼먽먾먿멀멁멂멃멄멅멆멇멈멉멊멋멌멍멎멏멐멑멒멓메멕멖멗멘멙멚멛멜멝멞멟멠멡멢멣멤멥멦멧멨멩멪멫멬멭멮멯며멱멲멳면멵멶멷멸멹멺멻멼멽멾멿몀몁몂몃몄명몆몇몈몉몊몋몌몍몎몏몐몑몒몓몔몕몖몗몘몙몚몛몜몝몞몟몠몡몢몣몤몥몦몧모목몪몫몬몭몮몯몰몱몲몳몴몵몶몷몸몹몺못몼몽몾몿뫀뫁뫂뫃뫄뫅뫆뫇뫈뫉뫊뫋뫌뫍뫎뫏뫐뫑뫒뫓뫔뫕뫖뫗뫘뫙뫚뫛뫜뫝뫞뫟뫠뫡뫢뫣뫤뫥뫦뫧뫨뫩뫪뫫뫬뫭뫮뫯뫰뫱뫲뫳뫴뫵뫶뫷뫸뫹뫺뫻뫼뫽뫾뫿묀묁묂묃묄묅묆묇묈묉묊묋묌묍묎묏묐묑묒묓묔묕묖묗묘묙묚묛묜묝묞묟묠묡묢묣묤묥묦묧묨묩묪묫묬묭묮묯묰묱묲묳무묵묶묷문묹묺묻물묽묾묿뭀뭁뭂뭃뭄뭅뭆뭇뭈뭉뭊뭋뭌뭍뭎뭏뭐뭑뭒뭓뭔뭕뭖뭗뭘뭙뭚뭛뭜뭝뭞뭟뭠뭡뭢뭣뭤뭥뭦뭧뭨뭩뭪뭫뭬뭭뭮뭯뭰뭱뭲뭳뭴뭵뭶뭷뭸뭹뭺뭻뭼뭽뭾뭿뮀뮁뮂뮃뮄뮅뮆뮇뮈뮉뮊뮋뮌뮍뮎뮏뮐뮑뮒뮓뮔뮕뮖뮗뮘뮙뮚뮛뮜뮝뮞뮟뮠뮡뮢뮣뮤뮥뮦뮧뮨뮩뮪뮫뮬뮭뮮뮯뮰뮱뮲뮳뮴뮵뮶뮷뮸뮹뮺뮻뮼뮽뮾뮿므믁믂믃믄믅믆믇믈믉믊믋믌믍믎믏믐믑믒믓믔믕믖믗믘믙믚믛믜믝믞믟믠믡믢믣믤믥믦믧믨믩믪믫믬믭믮믯믰믱믲믳믴믵믶믷미믹믺믻민믽믾믿밀밁밂밃밄밅밆밇밈밉밊밋밌밍밎및밐밑밒밓바박밖밗반밙밚받발밝밞밟밠밡밢밣밤밥밦밧밨방밪밫밬밭밮밯배백밲밳밴밵밶밷밸밹밺밻밼밽밾밿뱀뱁뱂뱃뱄뱅뱆뱇뱈뱉뱊뱋뱌뱍뱎뱏뱐뱑뱒뱓뱔뱕뱖뱗뱘뱙뱚뱛뱜뱝뱞뱟뱠뱡뱢뱣뱤뱥뱦뱧뱨뱩뱪뱫뱬뱭뱮뱯뱰뱱뱲뱳뱴뱵뱶뱷뱸뱹뱺뱻뱼뱽뱾뱿벀벁벂벃버벅벆벇번벉벊벋벌벍벎벏벐벑벒벓범법벖벗벘벙벚벛벜벝벞벟베벡벢벣벤벥벦벧벨벩벪벫벬벭벮벯벰벱벲벳벴벵벶벷벸벹벺벻벼벽벾벿변볁볂볃별볅볆볇볈볉볊볋볌볍볎볏볐병볒볓볔볕볖볗볘볙볚볛볜볝볞볟볠볡볢볣볤볥볦볧볨볩볪볫볬볭볮볯볰볱볲볳보복볶볷본볹볺볻볼볽볾볿봀봁봂봃봄봅봆봇봈봉봊봋봌봍봎봏봐봑봒봓봔봕봖봗봘봙봚봛봜봝봞봟봠봡봢봣봤봥봦봧봨봩봪봫봬봭봮봯봰봱봲봳봴봵봶봷봸봹봺봻봼봽봾봿뵀뵁뵂뵃뵄뵅뵆뵇뵈뵉뵊뵋뵌뵍뵎뵏뵐뵑뵒뵓뵔뵕뵖뵗뵘뵙뵚뵛뵜뵝뵞뵟뵠뵡뵢뵣뵤뵥뵦뵧뵨뵩뵪뵫뵬뵭뵮뵯뵰뵱뵲뵳뵴뵵뵶뵷뵸뵹뵺뵻뵼뵽뵾뵿부북붂붃분붅붆붇불붉붊붋붌붍붎붏붐붑붒붓붔붕붖붗붘붙붚붛붜붝붞붟붠붡붢붣붤붥붦붧붨붩붪붫붬붭붮붯붰붱붲붳붴붵붶붷붸붹붺붻붼붽붾붿뷀뷁뷂뷃뷄뷅뷆뷇뷈뷉뷊뷋뷌뷍뷎뷏뷐뷑뷒뷓뷔뷕뷖뷗뷘뷙뷚뷛뷜뷝뷞뷟뷠뷡뷢뷣뷤뷥뷦뷧뷨뷩뷪뷫뷬뷭뷮뷯뷰뷱뷲뷳뷴뷵뷶뷷뷸뷹뷺뷻뷼뷽뷾뷿븀븁븂븃븄븅븆븇븈븉븊븋브븍븎븏븐븑븒븓블븕븖븗븘븙븚븛븜븝븞븟븠븡븢븣븤븥븦븧븨븩븪븫븬븭븮븯븰븱븲븳븴븵븶븷븸븹븺븻븼븽븾븿빀빁빂빃비빅빆빇빈빉빊빋빌빍빎빏빐빑빒빓빔빕빖빗빘빙빚빛빜빝빞빟빠빡빢빣빤빥빦빧빨빩빪빫빬빭빮빯빰빱빲빳빴빵빶빷빸빹빺빻빼빽빾빿뺀뺁뺂뺃뺄뺅뺆뺇뺈뺉뺊뺋뺌뺍뺎뺏뺐뺑뺒뺓뺔뺕뺖뺗뺘뺙뺚뺛뺜뺝뺞뺟뺠뺡뺢뺣뺤뺥뺦뺧뺨뺩뺪뺫뺬뺭뺮뺯뺰뺱뺲뺳뺴뺵뺶뺷뺸뺹뺺뺻뺼뺽뺾뺿뻀뻁뻂뻃뻄뻅뻆뻇뻈뻉뻊뻋뻌뻍뻎뻏뻐뻑뻒뻓뻔뻕뻖뻗뻘뻙뻚뻛뻜뻝뻞뻟뻠뻡뻢뻣뻤뻥뻦뻧뻨뻩뻪뻫뻬뻭뻮뻯뻰뻱뻲뻳뻴뻵뻶뻷뻸뻹뻺뻻뻼뻽뻾뻿뼀뼁뼂뼃뼄뼅뼆뼇뼈뼉뼊뼋뼌뼍뼎뼏뼐뼑뼒뼓뼔뼕뼖뼗뼘뼙뼚뼛뼜뼝뼞뼟뼠뼡뼢뼣뼤뼥뼦뼧뼨뼩뼪뼫뼬뼭뼮뼯뼰뼱뼲뼳뼴뼵뼶뼷뼸뼹뼺뼻뼼뼽뼾뼿뽀뽁뽂뽃뽄뽅뽆뽇뽈뽉뽊뽋뽌뽍뽎뽏뽐뽑뽒뽓뽔뽕뽖뽗뽘뽙뽚뽛뽜뽝뽞뽟뽠뽡뽢뽣뽤뽥뽦뽧뽨뽩뽪뽫뽬뽭뽮뽯뽰뽱뽲뽳뽴뽵뽶뽷뽸뽹뽺뽻뽼뽽뽾뽿뾀뾁뾂뾃뾄뾅뾆뾇뾈뾉뾊뾋뾌뾍뾎뾏뾐뾑뾒뾓뾔뾕뾖뾗뾘뾙뾚뾛뾜뾝뾞뾟뾠뾡뾢뾣뾤뾥뾦뾧뾨뾩뾪뾫뾬뾭뾮뾯뾰뾱뾲뾳뾴뾵뾶뾷뾸뾹뾺뾻뾼뾽뾾뾿뿀뿁뿂뿃뿄뿅뿆뿇뿈뿉뿊뿋뿌뿍뿎뿏뿐뿑뿒뿓뿔뿕뿖뿗뿘뿙뿚뿛뿜뿝뿞뿟뿠뿡뿢뿣뿤뿥뿦뿧뿨뿩뿪뿫뿬뿭뿮뿯뿰뿱뿲뿳뿴뿵뿶뿷뿸뿹뿺뿻뿼뿽뿾뿿쀀쀁쀂쀃쀄쀅쀆쀇쀈쀉쀊쀋쀌쀍쀎쀏쀐쀑쀒쀓쀔쀕쀖쀗쀘쀙쀚쀛쀜쀝쀞쀟쀠쀡쀢쀣쀤쀥쀦쀧쀨쀩쀪쀫쀬쀭쀮쀯쀰쀱쀲쀳쀴쀵쀶쀷쀸쀹쀺쀻쀼쀽쀾쀿쁀쁁쁂쁃쁄쁅쁆쁇쁈쁉쁊쁋쁌쁍쁎쁏쁐쁑쁒쁓쁔쁕쁖쁗쁘쁙쁚쁛쁜쁝쁞쁟쁠쁡쁢쁣쁤쁥쁦쁧쁨쁩쁪쁫쁬쁭쁮쁯쁰쁱쁲쁳쁴쁵쁶쁷쁸쁹쁺쁻쁼쁽쁾쁿삀삁삂삃삄삅삆삇삈삉삊삋삌삍삎삏삐삑삒삓삔삕삖삗삘삙삚삛삜삝삞삟삠삡삢삣삤삥삦삧삨삩삪삫사삭삮삯산삱삲삳살삵삶삷삸삹삺삻삼삽삾삿샀상샂샃샄샅샆샇새색샊샋샌샍샎샏샐샑샒샓샔샕샖샗샘샙샚샛샜생샞샟샠샡샢샣샤샥샦샧샨샩샪샫샬샭샮샯샰샱샲샳샴샵샶샷샸샹샺샻샼샽샾샿섀섁섂섃섄섅섆섇섈섉섊섋섌섍섎섏섐섑섒섓섔섕섖섗섘섙섚섛서석섞섟선섡섢섣설섥섦섧섨섩섪섫섬섭섮섯섰성섲섳섴섵섶섷세섹섺섻센섽섾섿셀셁셂셃셄셅셆셇셈셉셊셋셌셍셎셏셐셑셒셓셔셕셖셗션셙셚셛셜셝셞셟셠셡셢셣셤셥셦셧셨셩셪셫셬셭셮셯셰셱셲셳셴셵셶셷셸셹셺셻셼셽셾셿솀솁솂솃솄솅솆솇솈솉솊솋소속솎솏손솑솒솓솔솕솖솗솘솙솚솛솜솝솞솟솠송솢솣솤솥솦솧솨솩솪솫솬솭솮솯솰솱솲솳솴솵솶솷솸솹솺솻솼솽솾솿쇀쇁쇂쇃쇄쇅쇆쇇쇈쇉쇊쇋쇌쇍쇎쇏쇐쇑쇒쇓쇔쇕쇖쇗쇘쇙쇚쇛쇜쇝쇞쇟쇠쇡쇢쇣쇤쇥쇦쇧쇨쇩쇪쇫쇬쇭쇮쇯쇰쇱쇲쇳쇴쇵쇶쇷쇸쇹쇺쇻쇼쇽쇾쇿숀숁숂숃숄숅숆숇숈숉숊숋숌숍숎숏숐숑숒숓숔숕숖숗수숙숚숛순숝숞숟술숡숢숣숤숥숦숧숨숩숪숫숬숭숮숯숰숱숲숳숴숵숶숷숸숹숺숻숼숽숾숿쉀쉁쉂쉃쉄쉅쉆쉇쉈쉉쉊쉋쉌쉍쉎쉏쉐쉑쉒쉓쉔쉕쉖쉗쉘쉙쉚쉛쉜쉝쉞쉟쉠쉡쉢쉣쉤쉥쉦쉧쉨쉩쉪쉫쉬쉭쉮쉯쉰쉱쉲쉳쉴쉵쉶쉷쉸쉹쉺쉻쉼쉽쉾쉿슀슁슂슃슄슅슆슇슈슉슊슋슌슍슎슏슐슑슒슓슔슕슖슗슘슙슚슛슜슝슞슟슠슡슢슣스슥슦슧슨슩슪슫슬슭슮슯슰슱슲슳슴습슶슷슸승슺슻슼슽슾슿싀싁싂싃싄싅싆싇싈싉싊싋싌싍싎싏싐싑싒싓싔싕싖싗싘싙싚싛시식싞싟신싡싢싣실싥싦싧싨싩싪싫심십싮싯싰싱싲싳싴싵싶싷싸싹싺싻싼싽싾싿쌀쌁쌂쌃쌄쌅쌆쌇쌈쌉쌊쌋쌌쌍쌎쌏쌐쌑쌒쌓쌔쌕쌖쌗쌘쌙쌚쌛쌜쌝쌞쌟쌠쌡쌢쌣쌤쌥쌦쌧쌨쌩쌪쌫쌬쌭쌮쌯쌰쌱쌲쌳쌴쌵쌶쌷쌸쌹쌺쌻쌼쌽쌾쌿썀썁썂썃썄썅썆썇썈썉썊썋썌썍썎썏썐썑썒썓썔썕썖썗썘썙썚썛썜썝썞썟썠썡썢썣썤썥썦썧써썩썪썫썬썭썮썯썰썱썲썳썴썵썶썷썸썹썺썻썼썽썾썿쎀쎁쎂쎃쎄쎅쎆쎇쎈쎉쎊쎋쎌쎍쎎쎏쎐쎑쎒쎓쎔쎕쎖쎗쎘쎙쎚쎛쎜쎝쎞쎟쎠쎡쎢쎣쎤쎥쎦쎧쎨쎩쎪쎫쎬쎭쎮쎯쎰쎱쎲쎳쎴쎵쎶쎷쎸쎹쎺쎻쎼쎽쎾쎿쏀쏁쏂쏃쏄쏅쏆쏇쏈쏉쏊쏋쏌쏍쏎쏏쏐쏑쏒쏓쏔쏕쏖쏗쏘쏙쏚쏛쏜쏝쏞쏟쏠쏡쏢쏣쏤쏥쏦쏧쏨쏩쏪쏫쏬쏭쏮쏯쏰쏱쏲쏳쏴쏵쏶쏷쏸쏹쏺쏻쏼쏽쏾쏿쐀쐁쐂쐃쐄쐅쐆쐇쐈쐉쐊쐋쐌쐍쐎쐏쐐쐑쐒쐓쐔쐕쐖쐗쐘쐙쐚쐛쐜쐝쐞쐟쐠쐡쐢쐣쐤쐥쐦쐧쐨쐩쐪쐫쐬쐭쐮쐯쐰쐱쐲쐳쐴쐵쐶쐷쐸쐹쐺쐻쐼쐽쐾쐿쑀쑁쑂쑃쑄쑅쑆쑇쑈쑉쑊쑋쑌쑍쑎쑏쑐쑑쑒쑓쑔쑕쑖쑗쑘쑙쑚쑛쑜쑝쑞쑟쑠쑡쑢쑣쑤쑥쑦쑧쑨쑩쑪쑫쑬쑭쑮쑯쑰쑱쑲쑳쑴쑵쑶쑷쑸쑹쑺쑻쑼쑽쑾쑿쒀쒁쒂쒃쒄쒅쒆쒇쒈쒉쒊쒋쒌쒍쒎쒏쒐쒑쒒쒓쒔쒕쒖쒗쒘쒙쒚쒛쒜쒝쒞쒟쒠쒡쒢쒣쒤쒥쒦쒧쒨쒩쒪쒫쒬쒭쒮쒯쒰쒱쒲쒳쒴쒵쒶쒷쒸쒹쒺쒻쒼쒽쒾쒿쓀쓁쓂쓃쓄쓅쓆쓇쓈쓉쓊쓋쓌쓍쓎쓏쓐쓑쓒쓓쓔쓕쓖쓗쓘쓙쓚쓛쓜쓝쓞쓟쓠쓡쓢쓣쓤쓥쓦쓧쓨쓩쓪쓫쓬쓭쓮쓯쓰쓱쓲쓳쓴쓵쓶쓷쓸쓹쓺쓻쓼쓽쓾쓿씀씁씂씃씄씅씆씇씈씉씊씋씌씍씎씏씐씑씒씓씔씕씖씗씘씙씚씛씜씝씞씟씠씡씢씣씤씥씦씧씨씩씪씫씬씭씮씯씰씱씲씳씴씵씶씷씸씹씺씻씼씽씾씿앀앁앂앃아악앆앇안앉않앋알앍앎앏앐앑앒앓암압앖앗았앙앚앛앜앝앞앟애액앢앣앤앥앦앧앨앩앪앫앬앭앮앯앰앱앲앳앴앵앶앷앸앹앺앻야약앾앿얀얁얂얃얄얅얆얇얈얉얊얋얌얍얎얏얐양얒얓얔얕얖얗얘얙얚얛얜얝얞얟얠얡얢얣얤얥얦얧얨얩얪얫얬얭얮얯얰얱얲얳어억얶얷언얹얺얻얼얽얾얿엀엁엂엃엄업없엇었엉엊엋엌엍엎엏에엑엒엓엔엕엖엗엘엙엚엛엜엝엞엟엠엡엢엣엤엥엦엧엨엩엪엫여역엮엯연엱엲엳열엵엶엷엸엹엺엻염엽엾엿였영옂옃옄옅옆옇예옉옊옋옌옍옎옏옐옑옒옓옔옕옖옗옘옙옚옛옜옝옞옟옠옡옢옣오옥옦옧온옩옪옫올옭옮옯옰옱옲옳옴옵옶옷옸옹옺옻옼옽옾옿와왁왂왃완왅왆왇왈왉왊왋왌왍왎왏왐왑왒왓왔왕왖왗왘왙왚왛왜왝왞왟왠왡왢왣왤왥왦왧왨왩왪왫왬왭왮왯왰왱왲왳왴왵왶왷외왹왺왻왼왽왾왿욀욁욂욃욄욅욆욇욈욉욊욋욌욍욎욏욐욑욒욓요욕욖욗욘욙욚욛욜욝욞욟욠욡욢욣욤욥욦욧욨용욪욫욬욭욮욯우욱욲욳운욵욶욷울욹욺욻욼욽욾욿움웁웂웃웄웅웆웇웈웉웊웋워웍웎웏원웑웒웓월웕웖웗웘웙웚웛웜웝웞웟웠웡웢웣웤웥웦웧웨웩웪웫웬웭웮웯웰웱웲웳웴웵웶웷웸웹웺웻웼웽웾웿윀윁윂윃위윅윆윇윈윉윊윋윌윍윎윏윐윑윒윓윔윕윖윗윘윙윚윛윜윝윞윟유육윢윣윤윥윦윧율윩윪윫윬윭윮윯윰윱윲윳윴융윶윷윸윹윺윻으윽윾윿은읁읂읃을읅읆읇읈읉읊읋음읍읎읏읐응읒읓읔읕읖읗의읙읚읛읜읝읞읟읠읡읢읣읤읥읦읧읨읩읪읫읬읭읮읯읰읱읲읳이익읶읷인읹읺읻일읽읾읿잀잁잂잃임입잆잇있잉잊잋잌잍잎잏자작잒잓잔잕잖잗잘잙잚잛잜잝잞잟잠잡잢잣잤장잦잧잨잩잪잫재잭잮잯잰잱잲잳잴잵잶잷잸잹잺잻잼잽잾잿쟀쟁쟂쟃쟄쟅쟆쟇쟈쟉쟊쟋쟌쟍쟎쟏쟐쟑쟒쟓쟔쟕쟖쟗쟘쟙쟚쟛쟜쟝쟞쟟쟠쟡쟢쟣쟤쟥쟦쟧쟨쟩쟪쟫쟬쟭쟮쟯쟰쟱쟲쟳쟴쟵쟶쟷쟸쟹쟺쟻쟼쟽쟾쟿저적젂젃전젅젆젇절젉젊젋젌젍젎젏점접젒젓젔정젖젗젘젙젚젛제젝젞젟젠젡젢젣젤젥젦젧젨젩젪젫젬젭젮젯젰젱젲젳젴젵젶젷져젹젺젻젼젽젾젿졀졁졂졃졄졅졆졇졈졉졊졋졌졍졎졏졐졑졒졓졔졕졖졗졘졙졚졛졜졝졞졟졠졡졢졣졤졥졦졧졨졩졪졫졬졭졮졯조족졲졳존졵졶졷졸졹졺졻졼졽졾졿좀좁좂좃좄종좆좇좈좉좊좋좌좍좎좏좐좑좒좓좔좕좖좗좘좙좚좛좜좝좞좟좠좡좢좣좤좥좦좧좨좩좪좫좬좭좮좯좰좱좲좳좴좵좶좷좸좹좺좻좼좽좾좿죀죁죂죃죄죅죆죇죈죉죊죋죌죍죎죏죐죑죒죓죔죕죖죗죘죙죚죛죜죝죞죟죠죡죢죣죤죥죦죧죨죩죪죫죬죭죮죯죰죱죲죳죴죵죶죷죸죹죺죻주죽죾죿준줁줂줃줄줅줆줇줈줉줊줋줌줍줎줏줐중줒줓줔줕줖줗줘줙줚줛줜줝줞줟줠줡줢줣줤줥줦줧줨줩줪줫줬줭줮줯줰줱줲줳줴줵줶줷줸줹줺줻줼줽줾줿쥀쥁쥂쥃쥄쥅쥆쥇쥈쥉쥊쥋쥌쥍쥎쥏쥐쥑쥒쥓쥔쥕쥖쥗쥘쥙쥚쥛쥜쥝쥞쥟쥠쥡쥢쥣쥤쥥쥦쥧쥨쥩쥪쥫쥬쥭쥮쥯쥰쥱쥲쥳쥴쥵쥶쥷쥸쥹쥺쥻쥼쥽쥾쥿즀즁즂즃즄즅즆즇즈즉즊즋즌즍즎즏즐즑즒즓즔즕즖즗즘즙즚즛즜증즞즟즠즡즢즣즤즥즦즧즨즩즪즫즬즭즮즯즰즱즲즳즴즵즶즷즸즹즺즻즼즽즾즿지직짂짃진짅짆짇질짉짊짋짌짍짎짏짐집짒짓짔징짖짗짘짙짚짛짜짝짞짟짠짡짢짣짤짥짦짧짨짩짪짫짬짭짮짯짰짱짲짳짴짵짶짷째짹짺짻짼짽짾짿쨀쨁쨂쨃쨄쨅쨆쨇쨈쨉쨊쨋쨌쨍쨎쨏쨐쨑쨒쨓쨔쨕쨖쨗쨘쨙쨚쨛쨜쨝쨞쨟쨠쨡쨢쨣쨤쨥쨦쨧쨨쨩쨪쨫쨬쨭쨮쨯쨰쨱쨲쨳쨴쨵쨶쨷쨸쨹쨺쨻쨼쨽쨾쨿쩀쩁쩂쩃쩄쩅쩆쩇쩈쩉쩊쩋쩌쩍쩎쩏쩐쩑쩒쩓쩔쩕쩖쩗쩘쩙쩚쩛쩜쩝쩞쩟쩠쩡쩢쩣쩤쩥쩦쩧쩨쩩쩪쩫쩬쩭쩮쩯쩰쩱쩲쩳쩴쩵쩶쩷쩸쩹쩺쩻쩼쩽쩾쩿쪀쪁쪂쪃쪄쪅쪆쪇쪈쪉쪊쪋쪌쪍쪎쪏쪐쪑쪒쪓쪔쪕쪖쪗쪘쪙쪚쪛쪜쪝쪞쪟쪠쪡쪢쪣쪤쪥쪦쪧쪨쪩쪪쪫쪬쪭쪮쪯쪰쪱쪲쪳쪴쪵쪶쪷쪸쪹쪺쪻쪼쪽쪾쪿쫀쫁쫂쫃쫄쫅쫆쫇쫈쫉쫊쫋쫌쫍쫎쫏쫐쫑쫒쫓쫔쫕쫖쫗쫘쫙쫚쫛쫜쫝쫞쫟쫠쫡쫢쫣쫤쫥쫦쫧쫨쫩쫪쫫쫬쫭쫮쫯쫰쫱쫲쫳쫴쫵쫶쫷쫸쫹쫺쫻쫼쫽쫾쫿쬀쬁쬂쬃쬄쬅쬆쬇쬈쬉쬊쬋쬌쬍쬎쬏쬐쬑쬒쬓쬔쬕쬖쬗쬘쬙쬚쬛쬜쬝쬞쬟쬠쬡쬢쬣쬤쬥쬦쬧쬨쬩쬪쬫쬬쬭쬮쬯쬰쬱쬲쬳쬴쬵쬶쬷쬸쬹쬺쬻쬼쬽쬾쬿쭀쭁쭂쭃쭄쭅쭆쭇쭈쭉쭊쭋쭌쭍쭎쭏쭐쭑쭒쭓쭔쭕쭖쭗쭘쭙쭚쭛쭜쭝쭞쭟쭠쭡쭢쭣쭤쭥쭦쭧쭨쭩쭪쭫쭬쭭쭮쭯쭰쭱쭲쭳쭴쭵쭶쭷쭸쭹쭺쭻쭼쭽쭾쭿쮀쮁쮂쮃쮄쮅쮆쮇쮈쮉쮊쮋쮌쮍쮎쮏쮐쮑쮒쮓쮔쮕쮖쮗쮘쮙쮚쮛쮜쮝쮞쮟쮠쮡쮢쮣쮤쮥쮦쮧쮨쮩쮪쮫쮬쮭쮮쮯쮰쮱쮲쮳쮴쮵쮶쮷쮸쮹쮺쮻쮼쮽쮾쮿쯀쯁쯂쯃쯄쯅쯆쯇쯈쯉쯊쯋쯌쯍쯎쯏쯐쯑쯒쯓쯔쯕쯖쯗쯘쯙쯚쯛쯜쯝쯞쯟쯠쯡쯢쯣쯤쯥쯦쯧쯨쯩쯪쯫쯬쯭쯮쯯쯰쯱쯲쯳쯴쯵쯶쯷쯸쯹쯺쯻쯼쯽쯾쯿찀찁찂찃찄찅찆찇찈찉찊찋찌찍찎찏찐찑찒찓찔찕찖찗찘찙찚찛찜찝찞찟찠찡찢찣찤찥찦찧차착찪찫찬찭찮찯찰찱찲찳찴찵찶찷참찹찺찻찼창찾찿챀챁챂챃채책챆챇챈챉챊챋챌챍챎챏챐챑챒챓챔챕챖챗챘챙챚챛챜챝챞챟챠챡챢챣챤챥챦챧챨챩챪챫챬챭챮챯챰챱챲챳챴챵챶챷챸챹챺챻챼챽챾챿첀첁첂첃첄첅첆첇첈첉첊첋첌첍첎첏첐첑첒첓첔첕첖첗처척첚첛천첝첞첟철첡첢첣첤첥첦첧첨첩첪첫첬청첮첯첰첱첲첳체첵첶첷첸첹첺첻첼첽첾첿쳀쳁쳂쳃쳄쳅쳆쳇쳈쳉쳊쳋쳌쳍쳎쳏쳐쳑쳒쳓쳔쳕쳖쳗쳘쳙쳚쳛쳜쳝쳞쳟쳠쳡쳢쳣쳤쳥쳦쳧쳨쳩쳪쳫쳬쳭쳮쳯쳰쳱쳲쳳쳴쳵쳶쳷쳸쳹쳺쳻쳼쳽쳾쳿촀촁촂촃촄촅촆촇초촉촊촋촌촍촎촏촐촑촒촓촔촕촖촗촘촙촚촛촜총촞촟촠촡촢촣촤촥촦촧촨촩촪촫촬촭촮촯촰촱촲촳촴촵촶촷촸촹촺촻촼촽촾촿쵀쵁쵂쵃쵄쵅쵆쵇쵈쵉쵊쵋쵌쵍쵎쵏쵐쵑쵒쵓쵔쵕쵖쵗쵘쵙쵚쵛최쵝쵞쵟쵠쵡쵢쵣쵤쵥쵦쵧쵨쵩쵪쵫쵬쵭쵮쵯쵰쵱쵲쵳쵴쵵쵶쵷쵸쵹쵺쵻쵼쵽쵾쵿춀춁춂춃춄춅춆춇춈춉춊춋춌춍춎춏춐춑춒춓추축춖춗춘춙춚춛출춝춞춟춠춡춢춣춤춥춦춧춨충춪춫춬춭춮춯춰춱춲춳춴춵춶춷춸춹춺춻춼춽춾춿췀췁췂췃췄췅췆췇췈췉췊췋췌췍췎췏췐췑췒췓췔췕췖췗췘췙췚췛췜췝췞췟췠췡췢췣췤췥췦췧취췩췪췫췬췭췮췯췰췱췲췳췴췵췶췷췸췹췺췻췼췽췾췿츀츁츂츃츄츅츆츇츈츉츊츋츌츍츎츏츐츑츒츓츔츕츖츗츘츙츚츛츜츝츞츟츠측츢츣츤츥츦츧츨츩츪츫츬츭츮츯츰츱츲츳츴층츶츷츸츹츺츻츼츽츾츿칀칁칂칃칄칅칆칇칈칉칊칋칌칍칎칏칐칑칒칓칔칕칖칗치칙칚칛친칝칞칟칠칡칢칣칤칥칦칧침칩칪칫칬칭칮칯칰칱칲칳카칵칶칷칸칹칺칻칼칽칾칿캀캁캂캃캄캅캆캇캈캉캊캋캌캍캎캏캐캑캒캓캔캕캖캗캘캙캚캛캜캝캞캟캠캡캢캣캤캥캦캧캨캩캪캫캬캭캮캯캰캱캲캳캴캵캶캷캸캹캺캻캼캽캾캿컀컁컂컃컄컅컆컇컈컉컊컋컌컍컎컏컐컑컒컓컔컕컖컗컘컙컚컛컜컝컞컟컠컡컢컣커컥컦컧컨컩컪컫컬컭컮컯컰컱컲컳컴컵컶컷컸컹컺컻컼컽컾컿케켁켂켃켄켅켆켇켈켉켊켋켌켍켎켏켐켑켒켓켔켕켖켗켘켙켚켛켜켝켞켟켠켡켢켣켤켥켦켧켨켩켪켫켬켭켮켯켰켱켲켳켴켵켶켷켸켹켺켻켼켽켾켿콀콁콂콃콄콅콆콇콈콉콊콋콌콍콎콏콐콑콒콓코콕콖콗콘콙콚콛콜콝콞콟콠콡콢콣콤콥콦콧콨콩콪콫콬콭콮콯콰콱콲콳콴콵콶콷콸콹콺콻콼콽콾콿쾀쾁쾂쾃쾄쾅쾆쾇쾈쾉쾊쾋쾌쾍쾎쾏쾐쾑쾒쾓쾔쾕쾖쾗쾘쾙쾚쾛쾜쾝쾞쾟쾠쾡쾢쾣쾤쾥쾦쾧쾨쾩쾪쾫쾬쾭쾮쾯쾰쾱쾲쾳쾴쾵쾶쾷쾸쾹쾺쾻쾼쾽쾾쾿쿀쿁쿂쿃쿄쿅쿆쿇쿈쿉쿊쿋쿌쿍쿎쿏쿐쿑쿒쿓쿔쿕쿖쿗쿘쿙쿚쿛쿜쿝쿞쿟쿠쿡쿢쿣쿤쿥쿦쿧쿨쿩쿪쿫쿬쿭쿮쿯쿰쿱쿲쿳쿴쿵쿶쿷쿸쿹쿺쿻쿼쿽쿾쿿퀀퀁퀂퀃퀄퀅퀆퀇퀈퀉퀊퀋퀌퀍퀎퀏퀐퀑퀒퀓퀔퀕퀖퀗퀘퀙퀚퀛퀜퀝퀞퀟퀠퀡퀢퀣퀤퀥퀦퀧퀨퀩퀪퀫퀬퀭퀮퀯퀰퀱퀲퀳퀴퀵퀶퀷퀸퀹퀺퀻퀼퀽퀾퀿큀큁큂큃큄큅큆큇큈큉큊큋큌큍큎큏큐큑큒큓큔큕큖큗큘큙큚큛큜큝큞큟큠큡큢큣큤큥큦큧큨큩큪큫크큭큮큯큰큱큲큳클큵큶큷큸큹큺큻큼큽큾큿킀킁킂킃킄킅킆킇킈킉킊킋킌킍킎킏킐킑킒킓킔킕킖킗킘킙킚킛킜킝킞킟킠킡킢킣키킥킦킧킨킩킪킫킬킭킮킯킰킱킲킳킴킵킶킷킸킹킺킻킼킽킾킿타탁탂탃탄탅탆탇탈탉탊탋탌탍탎탏탐탑탒탓탔탕탖탗탘탙탚탛태택탞탟탠탡탢탣탤탥탦탧탨탩탪탫탬탭탮탯탰탱탲탳탴탵탶탷탸탹탺탻탼탽탾탿턀턁턂턃턄턅턆턇턈턉턊턋턌턍턎턏턐턑턒턓턔턕턖턗턘턙턚턛턜턝턞턟턠턡턢턣턤턥턦턧턨턩턪턫턬턭턮턯터턱턲턳턴턵턶턷털턹턺턻턼턽턾턿텀텁텂텃텄텅텆텇텈텉텊텋테텍텎텏텐텑텒텓텔텕텖텗텘텙텚텛템텝텞텟텠텡텢텣텤텥텦텧텨텩텪텫텬텭텮텯텰텱텲텳텴텵텶텷텸텹텺텻텼텽텾텿톀톁톂톃톄톅톆톇톈톉톊톋톌톍톎톏톐톑톒톓톔톕톖톗톘톙톚톛톜톝톞톟토톡톢톣톤톥톦톧톨톩톪톫톬톭톮톯톰톱톲톳톴통톶톷톸톹톺톻톼톽톾톿퇀퇁퇂퇃퇄퇅퇆퇇퇈퇉퇊퇋퇌퇍퇎퇏퇐퇑퇒퇓퇔퇕퇖퇗퇘퇙퇚퇛퇜퇝퇞퇟퇠퇡퇢퇣퇤퇥퇦퇧퇨퇩퇪퇫퇬퇭퇮퇯퇰퇱퇲퇳퇴퇵퇶퇷퇸퇹퇺퇻퇼퇽퇾퇿툀툁툂툃툄툅툆툇툈툉툊툋툌툍툎툏툐툑툒툓툔툕툖툗툘툙툚툛툜툝툞툟툠툡툢툣툤툥툦툧툨툩툪툫투툭툮툯툰툱툲툳툴툵툶툷툸툹툺툻툼툽툾툿퉀퉁퉂퉃퉄퉅퉆퉇퉈퉉퉊퉋퉌퉍퉎퉏퉐퉑퉒퉓퉔퉕퉖퉗퉘퉙퉚퉛퉜퉝퉞퉟퉠퉡퉢퉣퉤퉥퉦퉧퉨퉩퉪퉫퉬퉭퉮퉯퉰퉱퉲퉳퉴퉵퉶퉷퉸퉹퉺퉻퉼퉽퉾퉿튀튁튂튃튄튅튆튇튈튉튊튋튌튍튎튏튐튑튒튓튔튕튖튗튘튙튚튛튜튝튞튟튠튡튢튣튤튥튦튧튨튩튪튫튬튭튮튯튰튱튲튳튴튵튶튷트특튺튻튼튽튾튿틀틁틂틃틄틅틆틇틈틉틊틋틌틍틎틏틐틑틒틓틔틕틖틗틘틙틚틛틜틝틞틟틠틡틢틣틤틥틦틧틨틩틪틫틬틭틮틯티틱틲틳틴틵틶틷틸틹틺틻틼틽틾틿팀팁팂팃팄팅팆팇팈팉팊팋파팍팎팏판팑팒팓팔팕팖팗팘팙팚팛팜팝팞팟팠팡팢팣팤팥팦팧패팩팪팫팬팭팮팯팰팱팲팳팴팵팶팷팸팹팺팻팼팽팾팿퍀퍁퍂퍃퍄퍅퍆퍇퍈퍉퍊퍋퍌퍍퍎퍏퍐퍑퍒퍓퍔퍕퍖퍗퍘퍙퍚퍛퍜퍝퍞퍟퍠퍡퍢퍣퍤퍥퍦퍧퍨퍩퍪퍫퍬퍭퍮퍯퍰퍱퍲퍳퍴퍵퍶퍷퍸퍹퍺퍻퍼퍽퍾퍿펀펁펂펃펄펅펆펇펈펉펊펋펌펍펎펏펐펑펒펓펔펕펖펗페펙펚펛펜펝펞펟펠펡펢펣펤펥펦펧펨펩펪펫펬펭펮펯펰펱펲펳펴펵펶펷편펹펺펻펼펽펾펿폀폁폂폃폄폅폆폇폈평폊폋폌폍폎폏폐폑폒폓폔폕폖폗폘폙폚폛폜폝폞폟폠폡폢폣폤폥폦폧폨폩폪폫포폭폮폯폰폱폲폳폴폵폶폷폸폹폺폻폼폽폾폿퐀퐁퐂퐃퐄퐅퐆퐇퐈퐉퐊퐋퐌퐍퐎퐏퐐퐑퐒퐓퐔퐕퐖퐗퐘퐙퐚퐛퐜퐝퐞퐟퐠퐡퐢퐣퐤퐥퐦퐧퐨퐩퐪퐫퐬퐭퐮퐯퐰퐱퐲퐳퐴퐵퐶퐷퐸퐹퐺퐻퐼퐽퐾퐿푀푁푂푃푄푅푆푇푈푉푊푋푌푍푎푏푐푑푒푓푔푕푖푗푘푙푚푛표푝푞푟푠푡푢푣푤푥푦푧푨푩푪푫푬푭푮푯푰푱푲푳푴푵푶푷푸푹푺푻푼푽푾푿풀풁풂풃풄풅풆풇품풉풊풋풌풍풎풏풐풑풒풓풔풕풖풗풘풙풚풛풜풝풞풟풠풡풢풣풤풥풦풧풨풩풪풫풬풭풮풯풰풱풲풳풴풵풶풷풸풹풺풻풼풽풾풿퓀퓁퓂퓃퓄퓅퓆퓇퓈퓉퓊퓋퓌퓍퓎퓏퓐퓑퓒퓓퓔퓕퓖퓗퓘퓙퓚퓛퓜퓝퓞퓟퓠퓡퓢퓣퓤퓥퓦퓧퓨퓩퓪퓫퓬퓭퓮퓯퓰퓱퓲퓳퓴퓵퓶퓷퓸퓹퓺퓻퓼퓽퓾퓿픀픁픂픃프픅픆픇픈픉픊픋플픍픎픏픐픑픒픓픔픕픖픗픘픙픚픛픜픝픞픟픠픡픢픣픤픥픦픧픨픩픪픫픬픭픮픯픰픱픲픳픴픵픶픷픸픹픺픻피픽픾픿핀핁핂핃필핅핆핇핈핉핊핋핌핍핎핏핐핑핒핓핔핕핖핗하학핚핛한핝핞핟할핡핢핣핤핥핦핧함합핪핫핬항핮핯핰핱핲핳해핵핶핷핸핹핺핻핼핽핾핿햀햁햂햃햄햅햆햇했행햊햋햌햍햎햏햐햑햒햓햔햕햖햗햘햙햚햛햜햝햞햟햠햡햢햣햤향햦햧햨햩햪햫햬햭햮햯햰햱햲햳햴햵햶햷햸햹햺햻햼햽햾햿헀헁헂헃헄헅헆헇허헉헊헋헌헍헎헏헐헑헒헓헔헕헖헗험헙헚헛헜헝헞헟헠헡헢헣헤헥헦헧헨헩헪헫헬헭헮헯헰헱헲헳헴헵헶헷헸헹헺헻헼헽헾헿혀혁혂혃현혅혆혇혈혉혊혋혌혍혎혏혐협혒혓혔형혖혗혘혙혚혛혜혝혞혟혠혡혢혣혤혥혦혧혨혩혪혫혬혭혮혯혰혱혲혳혴혵혶혷호혹혺혻혼혽혾혿홀홁홂홃홄홅홆홇홈홉홊홋홌홍홎홏홐홑홒홓화확홖홗환홙홚홛활홝홞홟홠홡홢홣홤홥홦홧홨황홪홫홬홭홮홯홰홱홲홳홴홵홶홷홸홹홺홻홼홽홾홿횀횁횂횃횄횅횆횇횈횉횊횋회획횎횏횐횑횒횓횔횕횖횗횘횙횚횛횜횝횞횟횠횡횢횣횤횥횦횧효횩횪횫횬횭횮횯횰횱횲횳횴횵횶횷횸횹횺횻횼횽횾횿훀훁훂훃후훅훆훇훈훉훊훋훌훍훎훏훐훑훒훓훔훕훖훗훘훙훚훛훜훝훞훟훠훡훢훣훤훥훦훧훨훩훪훫훬훭훮훯훰훱훲훳훴훵훶훷훸훹훺훻훼훽훾훿휀휁휂휃휄휅휆휇휈휉휊휋휌휍휎휏휐휑휒휓휔휕휖휗휘휙휚휛휜휝휞휟휠휡휢휣휤휥휦휧휨휩휪휫휬휭휮휯휰휱휲휳휴휵휶휷휸휹휺휻휼휽휾휿흀흁흂흃흄흅흆흇흈흉흊흋흌흍흎흏흐흑흒흓흔흕흖흗흘흙흚흛흜흝흞흟흠흡흢흣흤흥흦흧흨흩흪흫희흭흮흯흰흱흲흳흴흵흶흷흸흹흺흻흼흽흾흿힀힁힂힃힄힅힆힇히힉힊힋힌힍힎힏힐힑힒힓힔힕힖힗힘힙힚힛힜힝힞힟힠힡힢힣힤힥힦힧힨힩힪힫힬힭힮힯ᄀᄁᄂᄃᄄᄅᄆᄇᄈᄉᄊᄋᄌᄍᄎᄏᄐᄑᄒᄓᄔᄕᄖᄗᄘᄙᄚᄛᄜᄝᄞᄟᄠᄡᄢᄣᄤᄥᄦᄧᄨᄩᄪᄫᄬᄭᄮᄯᄰᄱᄲᄳᄴᄵᄶᄷᄸᄹᄺᄻᄼᄽᄾᄿᅀᅁᅂᅃᅄᅅᅆᅇᅈᅉᅊᅋᅌᅍᅎᅏᅐᅑᅒᅓᅔᅕᅖᅗᅘᅙᅚᅛᅜᅝᅞᅟᅠᅡᅢᅣᅤᅥᅦᅧᅨᅩᅪᅫᅬᅭᅮᅯᅰᅱᅲᅳᅴᅵᅶᅷᅸᅹᅺᅻᅼᅽᅾᅿᆀᆁᆂᆃᆄᆅᆆᆇᆈᆉᆊᆋᆌᆍᆎᆏᆐᆑᆒᆓᆔᆕᆖᆗᆘᆙᆚᆛᆜᆝᆞᆟᆠᆡᆢᆣᆤᆥᆦᆧᆨᆩᆪᆫᆬᆭᆮᆯᆰᆱᆲᆳᆴᆵᆶᆷᆸᆹᆺᆻᆼᆽᆾᆿᇀᇁᇂᇃᇄᇅᇆᇇᇈᇉᇊᇋᇌᇍᇎᇏᇐᇑᇒᇓᇔᇕᇖᇗᇘᇙᇚᇛᇜᇝᇞᇟᇠᇡᇢᇣᇤᇥᇦᇧᇨᇩᇪᇫᇬᇭᇮᇯᇰᇱᇲᇳᇴᇵᇶᇷᇸᇹᇺᇻᇼᇽᇾᇿ";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool ArmenianCharacter(string letter)
    {
        string charSet = "԰ԱԲԳԴԵԶԷԸԹԺԻԼԽԾԿՀՁՂՃՄՅՆՇՈՉՊՋՌՍՎՏՐՑՒՓՔՕՖ՗՘ՙ՚՛՜՝՞՟ՠաբգդեզէըթժիլխծկհձղճմյնշոչպջռսվտրցւփքօֆևֈ։֊֋֌֍֎֏";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool BengaliCharacter(string letter)
    {
        string charSet = "ঀঁংঃ঄অআইঈউঊঋঌ঍঎এঐ঑঒ওঔকখগঘঙচছজঝঞটঠডঢণতথদধন঩পফবভমযর঱ল঳঴঵শষসহ঺঻়ঽািীুূৃৄ৅৆েৈ৉৊োৌ্ৎ৏৐৑৒৓৔৕৖ৗ৘৙৚৛ড়ঢ়৞য়ৠৡৢৣ৤৥০১২৩৪৫৬৭৮৯ৰৱ৲৳৴৵৶৷৸৹৺৻ৼ৽৾৿";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool JapaneseCharacter(string letter)
    {
        string charSet = "぀ぁあぃいぅうぇえぉおかがきぎくぐけげこごさざしじすずせぜそぞただちぢっつづてでとどなにぬねのはばぱひびぴふぶぷへべぺほぼぽまみむめもゃやゅゆょよらりるれろゎわゐゑをんゔゕゖ゗゘゙゚゛゜ゝゞゟ゠ァアィイゥウェエォオカガキギクグケゲコゴサザシジスズセゼソゾタダチヂッツヅテデトドナニヌネノハバパヒビピフブプヘベペホボポマミムメモャヤュユョヨラリルレロヮワヰヱヲンヴヵヶヷヸヹヺ・ーヽヾヿ";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public bool SimplifiedChineseCharacter(string letter)
    {
        string charSet = "画海雀测试简体中文";

        for (int i = 0; i < charSet.Length - 1; i++)
        {
            if (charSet.Substring(i, 1) == letter)
            {
                return true;
            }
        }

        return false;
    }

    public string Reverse(string entry)
    {
        char[] charArray = entry.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public string Arabizer(string entry)
    {
        char[] charArray = entry.ToCharArray();
        int position = 1;
        string nonArabic = "";
        bool containsArabic = false;
        List<string> newEntry = new List<string>();

        for (int i = 0; i < entry.Length - 1; i++)
        {
            void FourFormLetter(char initial, char middle, char end, char isolate)
            {
                if (i + 1 <= entry.Length - 1)
                {
                    // Preserve non-Arabic characters.
                    nonArabic = "";

                    // If the next char is an Arabic letter
                    if (ArabicLetter(charArray[i + 1].ToString()))
                    {
                        if (position == 1)
                        {
                            charArray[i] = initial;
                            if (i + 2 <= entry.Length - 1)
                            {
                                if (ArabicLetter(charArray[i + 2].ToString()))
                                {
                                    position = 2;
                                }
                                else
                                {
                                    position = 3;
                                }
                            }
                            else
                            {
                                position = 3;
                            }
                        }
                        else if (position == 2)
                        {
                            charArray[i] = middle;
                            if (i + 2 <= entry.Length - 1)
                            {
                                if (ArabicLetter(charArray[i + 2].ToString()))
                                {
                                    position = 2;
                                }
                                else
                                {
                                    position = 3;
                                }
                            }
                            else
                            {
                                position = 3;
                            }
                        }
                        else if (position == 3)
                        {
                            charArray[i] = end;
                            position = 1;
                        }
                    }
                    else
                    {
                        if (position == 1)
                        {
                            charArray[i] = isolate;
                        }
                        else if (position == 2)
                        {
                            charArray[i] = end;
                        }
                        else if (position == 3)
                        {
                            charArray[i] = end;
                        }
                        position = 1;
                    }
                }
                else
                {
                    charArray[i] = end;
                    position = 1;
                }
            }
            void TwoFormLetter(char end, char isolate)
            {
                if (position == 1)
                {
                    charArray[i] = isolate;
                    position = 1;
                }
                else if (position == 2)
                {
                    charArray[i] = end;
                    position = 1;
                }
                else if (position == 3)
                {
                    charArray[i] = end;
                    position = 1;
                }
            }

            if (ArabicLetter(charArray[i].ToString()))
            {
                containsArabic = true;

                // Reverse nonArabic and put it back into the string
                if (nonArabic != "")
                {
                    for (int i2 = 0; i2 < nonArabic.Length; i2++)
                    {
                        charArray[i - nonArabic.Length + i2] = nonArabic.Substring(nonArabic.Length - (i2 + 1), 1)[0];
                    }

                    nonArabic = "";
                }

                if (charArray[i] == 'ا')
                {
                    if (charArray[i + 1] == 'ل' && charArray[i + 2] == 'ل' && charArray[i + 3] == 'ه')
                    {
                        charArray[i] = 'ﷲ';
                        charArray[i + 1] = '​';
                        charArray[i + 2] = '​';
                        charArray[i + 3] = '​';
                    }
                    else
                    {
                        TwoFormLetter('ﺎ', 'ﺍ');
                    }
                }
                else if (charArray[i] == 'ب')
                {
                    FourFormLetter('ﺑ', 'ﺒ', 'ﺐ', 'ﺏ');
                }
                else if (charArray[i] == 'ت')
                {
                    FourFormLetter('ﺗ', 'ﺘ', 'ﺖ', 'ﺕ');
                }
                else if (charArray[i] == 'ث')
                {
                    FourFormLetter('ﺛ', 'ﺜ', 'ﺚ', 'ﺙ');
                }
                else if (charArray[i] == 'ج')
                {
                    FourFormLetter('ﺟ', 'ﺠ', 'ﺞ', 'ﺝ');
                }
                else if (charArray[i] == 'ح')
                {
                    FourFormLetter('ﺣ', 'ﺤ', 'ﺢ', 'ﺡ');
                }
                else if (charArray[i] == 'خ')
                {
                    FourFormLetter('ﺧ', 'ﺨ', 'ﺦ', 'ﺥ');
                }
                else if (charArray[i] == 'د')
                {
                    TwoFormLetter('ﺪ', 'ﺩ');
                }
                else if (charArray[i] == 'ذ')
                {
                    TwoFormLetter('ﺬ', 'ﺫ');
                }
                else if (charArray[i] == 'ر')
                {
                    TwoFormLetter('ﺮ', 'ﺭ');
                }
                else if (charArray[i] == 'ز')
                {
                    TwoFormLetter('ﺰ', 'ﺯ');
                }
                else if (charArray[i] == 'س')
                {
                    FourFormLetter('ﺳ', 'ﺴ', 'ﺲ', 'ﺱ');
                }
                else if (charArray[i] == 'ش')
                {
                    FourFormLetter('ﺷ', 'ﺸ', 'ﺶ', 'ﺵ');
                }
                else if (charArray[i] == 'ص')
                {
                    FourFormLetter('ﺻ', 'ﺼ', 'ﺺ', 'ﺹ');
                }
                else if (charArray[i] == 'ض')
                {
                    FourFormLetter('ﺿ', 'ﻀ', 'ﺾ', 'ﺽ');
                }
                else if (charArray[i] == 'ط')
                {
                    FourFormLetter('ﻃ', 'ﻄ', 'ﻂ', 'ﻁ');
                }
                else if (charArray[i] == 'ظ')
                {
                    FourFormLetter('ﻇ', 'ﻈ', 'ﻆ', 'ﻅ');
                }
                else if (charArray[i] == 'ع')
                {
                    FourFormLetter('ﻋ', 'ﻌ', 'ﻊ', 'ﻉ');
                }
                else if (charArray[i] == 'غ')
                {
                    FourFormLetter('ﻏ', 'ﻐ', 'ﻎ', 'ﻍ');
                }
                else if (charArray[i] == 'ف')
                {
                    FourFormLetter('ﻓ', 'ﻔ', 'ﻒ', 'ﻑ');
                }
                else if (charArray[i] == 'ق')
                {
                    FourFormLetter('ﻗ', 'ﻘ', 'ﻖ', 'ﻕ');
                }
                else if (charArray[i] == 'ك')
                {
                    FourFormLetter('ﻛ', 'ﻜ', 'ﻚ', 'ﻙ');
                }
                else if (charArray[i] == 'ل')
                {
                    if (charArray[i + 1] == 'ا')
                    {
                        TwoFormLetter('ﻼ', 'ﻻ');
                        charArray[i + 1] = '​';
                    }
                    else if (charArray[i + 1] == 'آ')
                    {
                        TwoFormLetter('ﻶ', 'ﻵ');
                        charArray[i + 1] = '​';
                    }
                    else if (charArray[i + 1] == 'أ')
                    {
                        TwoFormLetter('ﻸ', 'ﻷ');
                        charArray[i + 1] = '​';
                    }
                    else if (charArray[i + 1] == 'إ')
                    {
                        TwoFormLetter('ﻺ', 'ﻹ');
                        charArray[i + 1] = '​';
                    }
                    else
                    {
                        FourFormLetter('ﻟ', 'ﻠ', 'ﻞ', 'ﻝ');
                    }
                }
                else if (charArray[i] == 'م')
                {
                    FourFormLetter('ﻣ', 'ﻤ', 'ﻢ', 'ﻡ');
                }
                else if (charArray[i] == 'ن')
                {
                    FourFormLetter('ﻧ', 'ﻨ', 'ﻦ', 'ﻥ');
                }
                else if (charArray[i] == 'ه')
                {
                    FourFormLetter('ﻫ', 'ﻬ', 'ﻪ', 'ﻩ');
                }
                else if (charArray[i] == 'و')
                {
                    TwoFormLetter('ﻮ', 'ﻭ');
                }
                else if (charArray[i] == 'ي')
                {
                    FourFormLetter('ﻳ', 'ﻴ', 'ﻲ', 'ﻱ');
                }
                else if (charArray[i] == 'ة')
                {
                    TwoFormLetter('ﺔ', 'ﺓ');
                }
                else if (charArray[i] == 'ى')
                {
                    TwoFormLetter('ﻰ', 'ﻰ'); //ﻯ
                }
                else if (charArray[i] == 'ء')
                {
                    TwoFormLetter('ﺀ', 'ﺀ');
                }
                else if (charArray[i] == 'آ')
                {
                    TwoFormLetter('ﺂ', 'ﺁ');
                }
                else if (charArray[i] == 'أ')
                {
                    TwoFormLetter('ﺄ', 'ﺃ');
                }
                else if (charArray[i] == 'إ')
                {
                    TwoFormLetter('ﺈ', 'ﺇ');
                }
                else if (charArray[i] == 'ؤ')
                {
                    TwoFormLetter('ﺆ', 'ﺅ');
                }
                else if (charArray[i] == 'ئ')
                {
                    FourFormLetter('ﺋ', 'ﺌ', 'ﺊ', 'ﺉ');
                }
                else if (charArray[i] == 'ٱ')
                {
                    TwoFormLetter('ﭑ', 'ﭐ');
                }
                else if (charArray[i] == 'ٻ')
                {
                    FourFormLetter('ﭔ', 'ﭕ', 'ﭓ', 'ﭒ');
                }
                else if (charArray[i] == 'پ')
                {
                    FourFormLetter('ﭘ', 'ﭙ', 'ﭗ', 'ﭖ');
                }
                else if (charArray[i] == 'ڀ')
                {
                    FourFormLetter('ﭜ', 'ﭝ', 'ﭛ', 'ﭚ');
                }
                else if (charArray[i] == 'ٺ')
                {
                    FourFormLetter('ﭠ', 'ﭡ', 'ﭟ', 'ﭞ');
                }
                else if (charArray[i] == 'ٿ')
                {
                    FourFormLetter('ﭤ', 'ﭥ', 'ﭣ', 'ﭢ');
                }
                else if (charArray[i] == 'ٹ')
                {
                    FourFormLetter('ﭨ', 'ﭩ', 'ﭧ', 'ﭦ');
                }
                else if (charArray[i] == 'ڤ')
                {
                    FourFormLetter('ﭬ', 'ﭭ', 'ﭫ', 'ﭪ');
                }
                else if (charArray[i] == 'ڦ')
                {
                    FourFormLetter('ﭰ', 'ﭱ', 'ﭯ', 'ﭮ');
                }
                else if (charArray[i] == 'ڄ')
                {
                    FourFormLetter('ﭴ', 'ﭵ', 'ﭳ', 'ﭲ');
                }
                else if (charArray[i] == 'ڃ')
                {
                    FourFormLetter('ﭸ', 'ﭹ', 'ﭷ', 'ﭶ');
                }
                else if (charArray[i] == 'چ')
                {
                    FourFormLetter('ﭼ', 'ﭽ', 'ﭻ', 'ﭺ');
                }
                else if (charArray[i] == 'ڇ')
                {
                    FourFormLetter('ﮀ', 'ﮁ', 'ﭿ', 'ﭾ');
                }
                else if (charArray[i] == 'ڍ')
                {
                    TwoFormLetter('ﮃ', 'ﮂ');
                }
                else if (charArray[i] == 'ڌ')
                {
                    TwoFormLetter('ﮅ', 'ﮄ');
                }
                else if (charArray[i] == 'ڎ')
                {
                    TwoFormLetter('ﮇ', 'ﮆ');
                }
                else if (charArray[i] == 'ڈ')
                {
                    TwoFormLetter('ﮉ', 'ﮈ');
                }
                else if (charArray[i] == 'ژ')
                {
                    TwoFormLetter('ﮋ', 'ﮊ');
                }
                else if (charArray[i] == 'ڑ')
                {
                    TwoFormLetter('ﮍ', 'ﮌ');
                }
                else if (charArray[i] == 'ک')
                {
                    FourFormLetter('ﮐ', 'ﮑ', 'ﮏ', 'ﮎ');
                }
                else if (charArray[i] == 'گ')
                {
                    FourFormLetter('ﮔ', 'ﮕ', 'ﮓ', 'ﮒ');
                }
                else if (charArray[i] == 'ڳ')
                {
                    FourFormLetter('ﮘ', 'ﮙ', 'ﮗ', 'ﮖ');
                }
                else if (charArray[i] == 'ڱ')
                {
                    FourFormLetter('ﮜ', 'ﮝ', 'ﮛ', 'ﮚ');
                }
                else if (charArray[i] == 'ں')
                {
                    TwoFormLetter('ﮟ', 'ﮞ');
                }
                else if (charArray[i] == 'ڻ')
                {
                    FourFormLetter('ﮢ', 'ﮣ', 'ﮡ', 'ﮠ');
                }
                else if (charArray[i] == 'ہ')
                {
                    FourFormLetter('ﮨ', 'ﮩ', 'ﮧ', 'ﮦ');
                }
                else if (charArray[i] == 'ھ')
                {
                    FourFormLetter('ﮬ', 'ﮭ', 'ﮫ', 'ﮪ');
                }
                else if (charArray[i] == 'ے')
                {
                    TwoFormLetter('ﮯ', 'ے');
                }
                else if (charArray[i] == 'ۓ')
                {
                    TwoFormLetter('ﮱ', 'ﮰ');
                }
                else if (charArray[i] == 'ڭ')
                {
                    FourFormLetter('ﯕ', 'ﯖ', 'ﯔ', 'ﯓ');
                }
                else if (charArray[i] == 'ۇ')
                {
                    TwoFormLetter('ﯘ', 'ﯗ');
                }
                else if (charArray[i] == 'ۆ')
                {
                    TwoFormLetter('ﯚ', 'ﯙ');
                }
                else if (charArray[i] == 'ۈ')
                {
                    TwoFormLetter('ﯜ', 'ﯛ');
                }
                else if (charArray[i] == 'ۋ')
                {
                    TwoFormLetter('ﯟ', 'ﯞ');
                }
                else if (charArray[i] == 'ۅ')
                {
                    TwoFormLetter('ﯡ', 'ﯠ');
                }
                else if (charArray[i] == 'ۉ')
                {
                    TwoFormLetter('ﯣ', 'ﯢ');
                }
                else if (charArray[i] == 'ې')
                {
                    FourFormLetter('ﯦ', 'ﯧ', 'ﯥ', 'ﯤ');
                }
                else if (charArray[i] == 'ی')
                {
                    FourFormLetter('ﯾ', 'ﯿ', 'ﯽ', 'ﯼ');
                }
            }
            else if (HebrewCharacter(charArray[i].ToString()))
            {
                containsArabic = true;

                if (nonArabic != "")
                {
                    for (int i2 = 0; i2 < nonArabic.Length; i2++)
                    {
                        charArray[i - nonArabic.Length + i2] = nonArabic.Substring(nonArabic.Length - (i2 + 1), 1)[0];
                    }

                    nonArabic = "";
                }
            }
            else
            {
                // Non-Arabic Character detected
                nonArabic += charArray[i].ToString();
            }
        }

        if (containsArabic == false)
        {
            Array.Reverse(charArray);
            nonArabic = "";
        }

        Array.Reverse(charArray);
        return new string(charArray);
    }
}
