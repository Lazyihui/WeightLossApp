using System;


namespace GJ {

    public class GameSystemContext {

        public SystemStatus status;
        public GameSystemEvents events;

        // ==== External ====
        public UICore ui;
        public AssetModule assetModule;
        public InputModule inputModule;
        public UserEntity userEntity;
        public GameEntity gameEntity;

        // ==== Internal ====

        public GameSystemContext() {
            events = new GameSystemEvents();
        }
    }
}