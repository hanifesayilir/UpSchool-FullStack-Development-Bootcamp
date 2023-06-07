import React from 'react';
import {NavLink} from "react-router-dom";
import {Menu, Image} from "semantic-ui-react";
import Container from "semantic-ui-react/dist/commonjs/elements/Container";

const NavBar = () => {
    return (
        <Menu fixed="top" inverted>
            <Container>
                <Menu.Item as="a" header>
                    <Image size="mini" src="/vite.svg" style={{ marginRight: "1.5em" }} />
                    UpStorage Task 6
                </Menu.Item>
                <Menu.Item as={NavLink} to="/">
                    ToDo Application
                </Menu.Item>
                <Menu.Item as={NavLink} to="/dafa">
                    Not Found
                </Menu.Item>
            </Container>
        </Menu>
    );
};

export default NavBar;
