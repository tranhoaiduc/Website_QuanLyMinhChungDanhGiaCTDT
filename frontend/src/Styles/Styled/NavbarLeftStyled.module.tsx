import styled from "styled-components";

export const NavbarLeftContainer = styled.div`
  height: 100vh;
  width: 100%;
  display: flex;
  flex-flow: column nowrap;
`;
export const BoxTitle = styled.div`
  height: 80px;
  width: 100%;
  display: flex;
  flex-flow: row nowrap;
  justify-content: center;
  align-items: center;
  background-color: rgba(0, 21, 41, 0.1);
`;

export const BoxTitleText = styled.span`
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  font-size: 25px;
  color: white;~
  user-select: none;
`;

export const BoxUser = styled.div`
  height: 170px;
  width: 100%;
  display: flex;
  flex-flow: row nowrap;
  justify-content: flex-start;
  background-color: rgb(0, 21, 41);
`;

export const BoxMenu = styled.div`
  height: calc(100vh - 220px);
  width: 100%;
  display: flex;
  flex-flow: row nowrap;
  background-color: rgb(0, 21, 41);
  overflow-y: auto;
  &::-webkit-scrollbar {
    width: 0;
  }
`;

export const BoxUserAvatar = styled.div`
  height: 100%;
  display: flex;
  flex-flow: row nowrap;
  justify-content: center;
  align-items: center;
`;

export const BoxUserAvatarImage = styled.img`
  height: 80px;
  width: 80px;
  border-radius: 50%;
`;

export const BoxUserInfo = styled.div`
  height: 100%;
  width: calc(100% - 80px);
  display: flex;
  flex-flow: column nowrap;
  align-items: flex-start;
  justify-content: center;
  padding-left: 10px;
  box-sizing: border-box;
`;

export const BoxUserInfoInline = styled.div`
  width: 100%;
  display: flex;
  flex-flow: row nowrap;
  align-items: center;
`;

export const BoxUserInfoText = styled.span`
  width: calc(100% - 25px);
  margin-left: 5px;
  text-overflow: ellipsis;
  white-space: nowrap;
  overflow: hidden;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  font-size: 14px;
  color: white;
  line-height: 35px;
  cursor: default;
  user-select: none;
  box-sizing: border-box;
`;
