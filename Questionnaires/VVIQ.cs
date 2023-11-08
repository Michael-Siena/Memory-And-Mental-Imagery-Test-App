﻿using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using CustomDataTypes;

namespace Questionnaires
{
    public sealed class VVIQ : Questionnaire
    {
        protected override void OnEnable() => base.OnEnable();

        public override void OnStartButtonPress() => base.OnStartButtonPress();

        public override void OnNextButtonPress() => base.OnNextButtonPress();

        public override void OnPrevButtonPress() => base.OnPrevButtonPress();

        public override void OnSubmitButtonPress() => base.OnSubmitButtonPress();


        protected override string ConvertDataToString(List<int> data) => base.ConvertDataToString(data);

        protected override void LoadNextScene()
        {
            switch (Global.SessionInfo.QuestionnaireOrder)
            {
                case QuestionnaireOrderType.VVIQthenOSIQthenSAM: case QuestionnaireOrderType.SAMthenVVIQthenOSIQ:
                    SceneManager.LoadScene(QuestionnaireType.OSIQ.ToString());
                    break;
                case QuestionnaireOrderType.VVIQthenSAMthenOSIQ: case QuestionnaireOrderType.OSIQthenVVIQthenSAM:
                    SceneManager.LoadScene(QuestionnaireType.SAM.ToString());
                    break;
                case QuestionnaireOrderType.OSIQthenSAMthenVVIQ: case QuestionnaireOrderType.SAMthenOSIQthenVVIQ:
                    switch (Global.SessionInfo.TaskOrder)
                    {
                        case TaskOrderType.MemoryTaskThenQuestionnaires:
                            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
                            break;
                        case TaskOrderType.QuestionnairesThenMemoryTask:
                            SceneManager.LoadScene("TaskOverview Instructions");
                            break;
                    }
                    break;
            }
        }

        protected override void OnDisable() => base.OnDisable();
    }
}