﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jurassic;
using Jurassic.Library;
using iconnect;

namespace scripting
{
    class JSScript
    {
        public String ScriptName { get; private set; }
        public ScriptEngine JS { get; private set; }
        public List<Objects.JSUser> local_users = new List<Objects.JSUser>();
        public List<Objects.JSLeaf> leaves = new List<Objects.JSLeaf>();

        public JSScript(String name)
        {
            this.ScriptName = name;
            this.JS = new ScriptEngine();
            this.JS.ScriptName = name;

            // set up default events
            StringBuilder events = new StringBuilder();
            events.AppendLine("function onTextReceived(userobj, text) { }");
            events.AppendLine("function onTextBefore(userobj, text) { return text; }");
            events.AppendLine("function onTextAfter(userobj, text) { }");
            events.AppendLine("function onEmoteReceived(userobj, text) { }");
            events.AppendLine("function onEmoteBefore(userobj, text) { return text; }");
            events.AppendLine("function onEmoteAfter(userobj, text) { }");
            events.AppendLine("function onError(script, line, message) { }");
            events.AppendLine("function onJoinCheck(userobj) { return true; }");
            events.AppendLine("function onJoin(userobj) { }");
            events.AppendLine("function onPartBefore(userobj) { }");
            events.AppendLine("function onPart(userobj) { }");
            events.AppendLine("function onTimer() { }");
            events.AppendLine("function onHelp(userobj) { }");
            events.AppendLine("function onCommand(userobj, command, target, args) { }");
            events.AppendLine("function onAvatar(userobj) { return true; }");
            events.AppendLine("function onPersonalMessage(userobj, msg) { return true; }");
            events.AppendLine("function onRejected(userobj) { }");
            events.AppendLine("function onLoad() { }");
            events.AppendLine("function onUnload() { }");
            events.AppendLine("function onVroomJoinCheck(userobj, vroom) { return true; }");
            events.AppendLine("function onVroomJoin(userobj) { }");
            events.AppendLine("function onFileReceived(userobj, filename) { }");
            events.AppendLine("function onFloodBefore(userobj, msg) { return true; }");
            events.AppendLine("function onFlood(userobj) { }");
            events.AppendLine("function onBotPM(userobj, text) { return true; }");
            events.AppendLine("function onPMBefore(userobj, target, pm) { return true; }");
            events.AppendLine("function onPM(userobj, target) { }");
            events.AppendLine("function onNick(userobj, name) { return true; }");
            events.AppendLine("function onIgnoring(userobj, target) { return true; }");
            events.AppendLine("function onIgnoredStateChanged(userobj, target, ignored) { }");
            events.AppendLine("function onInvalidLoginAttempt(userobj) { }");
            events.AppendLine("function onLoginGranted(userobj) { }");
            events.AppendLine("function onAdminLevelChanged(userobj) { }");
            events.AppendLine("function onRegistering(userobj) { return true; }");
            events.AppendLine("function onRegistered(userobj) { }");
            events.AppendLine("function onUnregistered(userobj) { }");
            events.AppendLine("function onCaptchaSending(userobj) { }");
            events.AppendLine("function onCaptchaReply(userobj, reply) { }");
            events.AppendLine("function onProxyDetected(userobj, reply) { return true; }");
            events.AppendLine("function onLogout(userobj) { }");
            events.AppendLine("function onIdled(userobj) { }");
            events.AppendLine("function onUnidled(userobj, seconds) { }");
            events.AppendLine("function onBansAutoCleared() { }");
            events.AppendLine("function onLinkError(msg) { }");
            events.AppendLine("function onLinked() { }");
            events.AppendLine("function onUnlinked() { }");
            events.AppendLine("function onLeafJoin(leaf) { }");
            events.AppendLine("function onLeafPart(leaf) { }");
            events.AppendLine("function onLinkedAdminDisabled(leaf, userobj) { }");
            this.JS.Evaluate(events.ToString());
        }

        public Objects.JSUser GetUser(IUser client)
        {
            if (client == null)
                return null;

            Objects.JSUser result = this.local_users.Find(x => x.Name == client.Name);

            return result;
        }

        public Objects.JSUser GetUser(Predicate<Objects.JSUser> predicate)
        {
            return this.local_users.Find(predicate);
        }
    }
}