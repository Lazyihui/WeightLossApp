using System;
using UnityEngine;
using GJ.Systems_Game;


namespace GJ {

    public class GameSystem {

        GameSystemContext ctx;
        public GameSystemEvents Events => ctx.events;

        public GameSystem() {
            ctx = new GameSystemContext();
        }

        public void Inject(AssetModule assetModule, UICore ui,
        GameEntity gameEntity,
        InputModule inputModule
        , UserEntity userEntity
        ) {
            ctx.ui = ui;
            ctx.assetModule = assetModule;
            ctx.gameEntity = gameEntity;
            ctx.userEntity = userEntity;
            ctx.inputModule = inputModule;
        }
        #region Tick
        public void Tick(float dt) {

            if (ctx.status != SystemStatus.Running) {
                return;
            }

            PreTick(dt);

            ref float restSec = ref ctx.gameEntity.restSec;
            restSec += dt;
            const float interval = 0.05f;
            while (restSec > 0) {
                float step = Math.Min(interval, restSec);
                restSec -= step;
                FixTick(step);
            }

            LateTick(dt);

        }

        void PreTick(float dt) {
        }

        void FixTick(float dt) {

        }

        void LateTick(float dt) {
        }
        #endregion

        #region  Events
        public void NewGame() {
            SystemController.NewGame(ctx);
            Debug.Log("新游戏");
        }

        public void OnResume() {
            SystemController.OnResume(ctx);
        }

        public void OnExitGame() {
            SystemController.OnExitGame(ctx);
            Debug.Log("退出游戏");
        }

        #endregion

    }
}