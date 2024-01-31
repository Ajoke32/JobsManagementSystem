


export enum DelayType{
    Thread,
    Task,
    Chrome
}

export interface ParsingOptions{
  sendNotifications:boolean,
  sendPercentageNotification:boolean,
  sendParsedPagesNotification:boolean,
  delayMs:number,
  delayType:DelayType,
  maxPages:number,
  itemsPerPage:number
}


