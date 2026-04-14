using System;
using System.Collections.Generic;

namespace CybersecurityAwarenessBot
{
    public class ResponseManager
    {
        private static readonly Random random = new Random();

        private Dictionary<string, List<string>> keywordResponses;
        private Dictionary<string, List<string>> detailedResponses;
        private Dictionary<string, List<string>> exampleResponses;

        private List<string> defaultResponses;

        private string lastTopic;
        private int followUpCount;

        public ResponseManager()
        {
            keywordResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            detailedResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            exampleResponses = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            InitializeResponses();
        }

        private void InitializeResponses()
        {
            // ========== GREETINGS ==========
            keywordResponses["how are you"] = new List<string>
            {
                "I'm doing well, {user}! Thanks for asking. How can I help you with cybersecurity today?",
                "I'm great! Ready to share some online safety tips with you, {user}!",
                "All systems operational! What can I teach you about staying safe online, {user}?",
                "Feeling secure and ready to help, {user}! What would you like to learn about today?"
            };

            // ========== PURPOSE ==========
            keywordResponses["what is your purpose"] = new List<string>
            {
                "My purpose is to help you stay safe online! I provide tips about password safety, phishing, and safe browsing."
            };

            // ========== WHAT CAN I ASK ==========
            keywordResponses["what can i ask you about "] = new List<string>
            {
                "You can ask me about:\n• Password safety\n• Phishing attacks\n• Safe browsing habits\n• General cybersecurity tips"
            };

            // ========== PHISHING ==========
            var phishingPrimary = new List<string>
            {
                "🎣 Phishing is a cyberattack where criminals send fake emails, messages, or websites that look legitimate to trick you into revealing personal information like passwords, credit card numbers, or Social Security numbers. Never click suspicious links!",
                "Phishing attacks impersonate trusted companies (like banks, Amazon, or PayPal) to steal your data. Signs include urgent language, spelling errors, and generic greetings like 'Dear Customer'."
            };
            AddKeywords(keywordResponses, phishingPrimary,
                "phishing", "define phishing", "what is phishing", "phishing email", "phishing attack", "phish"
            );

            detailedResponses["phishing"] = new List<string>
            {
                "Here are more details about phishing:\n\n• Always hover over links before clicking to see the actual URL. Fake links often have misspellings like 'arnazon.com' instead of 'amazon.com'.\n• Check the sender's email address carefully - it might be 'support@paypa1.com' instead of 'support@paypal.com'.\n• Legitimate companies never ask for your password or credit card info via email.\n• If you receive a suspicious email, report it as spam and delete it.",
                "Phishing can also happen via SMS text messages (called 'smishing') or phone calls ('vishing'). Never give personal information over the phone unless you initiated the call to a verified number."
            };

            exampleResponses["phishing"] = new List<string>
            {
                "Example of a phishing email:\n\nSubject: Your account has been locked!\nFrom: security@paypa1.com\nMessage: 'Dear Customer, We noticed unusual activity on your account. Click here to verify your identity immediately or your account will be closed.'\n\n🚩 Red flags: Generic greeting, urgent tone, misspelled sender address, suspicious link.",
                "Real-world example: In 2020, Twitter employees fell for a phishing attack that gave hackers access to high-profile accounts like Elon Musk and Barack Obama. The attackers then posted bitcoin scams. Always verify before clicking!"
            };

            // ========== PASSWORD SAFETY ==========
            var passwordPrimary = new List<string>
            {
                "🔐 Password safety means creating strong, unique passwords for each account. A strong password has at least 12 characters with a mix of uppercase, lowercase, numbers, and symbols. Never reuse passwords across different sites!",
                "Use a password manager to generate and store complex passwords. Enable Two-Factor Authentication (2FA) whenever available - it adds a second layer of security even if your password is stolen."
            };
            AddKeywords(keywordResponses, passwordPrimary,
                "password", "strong password", "create a password", "password safety",
                "define password", "what is a password", "how to make a password",
                "how to create a strong password"
            );

            detailedResponses["password"] = new List<string>
            {
                "More password tips:\n\n• Avoid common words like 'password', '123456', or 'qwerty' - hackers try these first.\n• Use a passphrase: combine 4 random words like 'Correct-Horse-Battery-Staple' - it's long and memorable.\n• Never write passwords on sticky notes or share them with anyone.\n• Change your password immediately if you suspect a breach.",
                "Password managers like Bitwarden, LastPass, or 1Password create strong random passwords for every site. You only need to remember one master password. They also autofill so you avoid typos."
            };

            exampleResponses["password"] = new List<string>
            {
                "Example of a strong password: 'P@ssw0rd!2024' is actually weak because it uses common substitutions. Better: 'PurpleDinosaurEatsPizza@3am!' - easy to remember, hard to crack.\n\nWeak passwords to avoid: 123456, password, qwerty, admin, letmein, your name, your birthday.",
                "Example of 2FA: After entering your password, you receive a text code, or use an authenticator app like Google Authenticator. Even if a hacker steals your password, they can't log in without that second code."
            };

            // ========== SAFE BROWSING ==========
            var browsingPrimary = new List<string>
            {
                "🌐 Safe browsing means protecting your data while online. Always look for 'https://' and the padlock icon in the address bar before entering passwords or credit card info. Avoid using public Wi-Fi for sensitive transactions.",
                "Keep your browser and extensions updated. Use an ad-blocker to avoid malicious ads that can infect your device. Consider using a VPN on public networks to encrypt your traffic."
            };
            AddKeywords(keywordResponses, browsingPrimary,
                "safe browsing", "browsing", "define safe browsing", "what is safe browsing",
                "https", "vpn", "public wi-fi", "public wifi"
            );

            detailedResponses["safe browsing"] = new List<string>
            {
                "Additional safe browsing practices:\n\n• Clear your browser cookies and cache regularly.\n• Use private/incognito mode for sensitive searches.\n• Install browser extensions like HTTPS Everywhere to force encrypted connections.\n• Be careful what extensions you install - some steal your data.",
                "On public Wi-Fi: Turn off file sharing, enable your firewall, and use a trusted VPN. Better yet, use your phone's hotspot instead of free public networks. Hackers can set up fake 'Free Wi-Fi' hotspots to intercept your data."
            };

            exampleResponses["safe browsing"] = new List<string>
            {
                "Example: You're at a coffee shop and see 'Free Coffee Wi-Fi' and 'Coffee Shop Official'. The first might be a hacker's fake network. Always ask staff for the official network name.\n\nAnother example: A pop-up ad claims your computer is infected and asks you to call a number. That's a scam - never call those numbers.",
                "Example of HTTPS: When you visit your bank's website, the URL should start with https:// and show a padlock. If you see http:// (without the 's'), your connection is not encrypted and someone on the same network could see your login details."
            };

            // ========== GENERAL CYBERSECURITY ==========
            var generalPrimary = new List<string>
            {
                "Cybersecurity is the practice of protecting your devices, networks, and data from digital attacks. Key habits: use strong passwords, enable 2FA, keep software updated, back up your data, and be cautious online.",
                "Always keep your software updated! Updates include security patches for known vulnerabilities. Enable automatic updates on your operating system, browser, and apps."
            };

            AddKeywords(keywordResponses, generalPrimary,
                "cybersecurity", "define cybersecurity", "what is cybersecurity",
                "update", "backup", "social media"
            );

            detailedResponses["cybersecurity"] = new List<string>
            {
                "More cybersecurity practices:\n\n• Lock your screen when away from your computer (Windows + L).\n• Don't plug in unknown USB drives - they could contain malware.\n• Be careful what you post on social media - oversharing helps hackers answer security questions.\n• Use a separate email for important accounts like banking.",
                "Back up your data regularly using the 3-2-1 rule: 3 copies of your data, on 2 different types of media, with 1 copy stored off-site (cloud or external drive). This protects you from ransomware."
            };

            exampleResponses["cybersecurity"] = new List<string>
            {
                "Example: In 2017, the WannaCry ransomware infected over 200,000 computers worldwide. It exploited a vulnerability that Microsoft had already patched - but people who didn't update got locked out of their files.\n\nExample of social media oversharing: Posting 'Happy birthday to my dog Max!' gives hackers a possible answer to security question 'What is your pet's name?'",
                "Example of a security breach: The 2019 Capital One breach exposed 100 million customers' data because a misconfigured firewall allowed access. Always review your bank statements for unauthorized activity."
            };

            defaultResponses = new List<string>
            {
                "I didn't quite understand that. Could you rephrase? Try asking me about password safety, phishing, or safe browsing.",
                "I'm not sure about that. Would you like to learn about cybersecurity topics like passwords, phishing, or safe browsing?",
                "That's an interesting question! However, I specialize in cybersecurity. Ask me 'What is phishing?' or 'How do I create a strong password?'",
                "Hmm, I don't have information on that. Try asking 'Define phishing' or 'What is safe browsing?'"
            };
        }

        private void AddKeywords(
            Dictionary<string, List<string>> map,
            List<string> responses,
            params string[] keywords
        )
        {
            foreach (var kw in keywords)
                map[kw] = responses;
        }

        public string GetResponse(string userInput)
        {
            string input = userInput.ToLower().Trim();
            input = FixMisspellings(input);

            if (IsFollowUpQuestion(input))
                return HandleFollowUp();

            string topicFromInput = ExtractTopicFromInput(input);
            if (topicFromInput != null && keywordResponses.ContainsKey(topicFromInput))
            {
                lastTopic = topicFromInput;
                followUpCount = 0;
                return PickRandom(keywordResponses[topicFromInput]);
            }

            // Keyword matching (simple contains approach like your version)
            foreach (var kvp in keywordResponses)
            {
                if (input.Contains(kvp.Key.ToLower()))
                {
                    lastTopic = DetermineTopicFromKeyword(kvp.Key);
                    followUpCount = 0;
                    return PickRandom(kvp.Value);
                }
            }

            return PickRandom(defaultResponses);
        }

        private string HandleFollowUp()
        {
            if (lastTopic == null)
                return "Please ask me about a specific cybersecurity topic first (like phishing, passwords, or safe browsing), then I can elaborate further.";

            followUpCount++;

            if (followUpCount == 1 && detailedResponses.ContainsKey(lastTopic))
                return PickRandom(detailedResponses[lastTopic]);

            if (followUpCount >= 2 && exampleResponses.ContainsKey(lastTopic))
                return PickRandom(exampleResponses[lastTopic]);

            if (detailedResponses.ContainsKey(lastTopic))
                return PickRandom(detailedResponses[lastTopic]);

            return PickRandom(defaultResponses);
        }

        private string PickRandom(List<string> list)
        {
            return list[random.Next(list.Count)];
        }

        private string FixMisspellings(string input)
        {
            var misspellings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "phising", "phishing" },
                { "phisihng", "phishing" },
                { "passowrd", "password" },
                { "pasword", "password" },
                { "cyber security", "cybersecurity" },
                { "safe broswing", "safe browsing" },
                { "elaborate futher", "elaborate further" }
            };

            foreach (var pair in misspellings)
            {
                if (input.Contains(pair.Key))
                    input = input.Replace(pair.Key, pair.Value);
            }

            return input;
        }

        private string ExtractTopicFromInput(string input)
        {
            string[] topics = { "phishing", "password", "safe browsing", "cybersecurity" };

            foreach (var topic in topics)
            {
                if (input.Contains(topic))
                    return topic;
            }

            return null;
        }

        private bool IsFollowUpQuestion(string input)
        {
            string[] followUpPhrases =
            {
                "elaborate", "tell me more", "explain further", "more details",
                "go on", "continue", "what else", "elaborate more", "more info",
                "can you elaborate", "tell me more about", "explain more",
                "explain further", "futher", "further", "give me examples", "examples",
                "more about", "tell me about", "elaborate on"
            };

            foreach (var phrase in followUpPhrases)
            {
                if (input.Contains(phrase))
                    return true;
            }

            return false;
        }

        private string DetermineTopicFromKeyword(string keyword)
        {
            if (keyword.Contains("phish")) return "phishing";
            if (keyword.Contains("password") || keyword.Contains("2fa") || keyword.Contains("multi factor")) return "password";
            if (keyword.Contains("browsing") || keyword.Contains("https") || keyword.Contains("vpn") || keyword.Contains("wi-fi") || keyword.Contains("wifi")) return "safe browsing";
            if (keyword.Contains("cyber") || keyword.Contains("update") || keyword.Contains("backup") || keyword.Contains("social media")) return "cybersecurity";

            return keyword;
        }
    }
}