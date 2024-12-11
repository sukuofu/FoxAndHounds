using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム階層のマスタデータ
/// 決め打ちであまりいじらない想定です
/// </summary>
public static class FloorData
{
    /// <summary>
    /// フロアデータの構造
    /// </summary>
    public class FloorDataRow
    {
        /// <summary>
        /// 表示上の名前
        /// </summary>
        public string FloorLabel { get; set; }

        /// <summary>
        /// prefabsの名前と紐づけるID
        /// </summary>
        public string FloorId { get; set; }

        /// <summary>
        /// エリア内の最終階層かどうか
        /// </summary>
        public bool IsLastOfArea { get; set; }

        /// <summary>
        /// 最後のステージかどうか
        /// </summary>
        public bool IsFinalStage { get; set; }
    }

    /// <summary>
    /// フロアの構造を決めるマスタデータ本体
    /// GameControllerがこれを読み込んでPrefabから生成しています
    /// </summary>
    public static List<FloorDataRow> FloorDataRows =
    new List<FloorDataRow>()
    {
        new(){FloorLabel =  "A棟 / 1階層", FloorId = "1-1", IsLastOfArea = false, IsFinalStage = false},
        new(){FloorLabel =  "A棟 / 2階層", FloorId = "1-2", IsLastOfArea = false, IsFinalStage = false},
        new(){FloorLabel =  "A棟 / 3階層", FloorId = "1-3", IsLastOfArea = true, IsFinalStage = false},
        new(){FloorLabel =  "B棟 / 1階層", FloorId = "2-1", IsLastOfArea = false, IsFinalStage = false},
        new(){FloorLabel =  "B棟 / 2階層", FloorId = "2-2", IsLastOfArea = false, IsFinalStage = false},
        new(){FloorLabel =  "B棟 / 3階層", FloorId = "2-3", IsLastOfArea = true, IsFinalStage = false},
        new(){FloorLabel =  "C棟 / 1階層", FloorId = "3-1", IsLastOfArea = false, IsFinalStage = false},
        new(){FloorLabel =  "C棟 / 2階層", FloorId = "3-2", IsLastOfArea = false, IsFinalStage = false},
        new(){FloorLabel =  "C棟 / 3階層", FloorId = "3-3", IsLastOfArea = true, IsFinalStage = true}
    };

}
