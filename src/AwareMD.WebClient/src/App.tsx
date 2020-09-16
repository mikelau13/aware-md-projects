import React, { useState, Suspense, lazy } from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";
import ErrorModal from './components/Alert/errorModal';

import {
  createMuiTheme,
  createStyles,
  ThemeProvider,
  withStyles,
  WithStyles,
} from '@material-ui/core/styles';
import { 
  CssBaseline,
  Hidden,
  Typography,
  Link
} from '@material-ui/core';
import LeftNavigator from './components/Menu/leftNavigator';
import Header from './components/Header/header';
import Loading from './components/Common/loading';

const Calendar = lazy(() => import("./components/Calendar/calendar"));

function Copyright() {
  return (
    <Typography variant="body2" color="textSecondary" align="center">
      {'Copyright © '}
      <Link color="inherit" href="mailto:mikelau13@hotmail.com">
        {'Mike Lau'}
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

let theme = createMuiTheme({
  palette: {
    primary: {
      light: '#63ccff',
      main: '#009be5',
      dark: '#006db3',
    },
  },
  typography: {
    h5: {
      fontWeight: 500,
      fontSize: 26,
      letterSpacing: 0.5,
    },
  },
  shape: {
    borderRadius: 8,
  },
  props: {
    MuiTab: {
      disableRipple: true,
    },
  },
  mixins: {
    toolbar: {
      minHeight: 48,
    },
  },
});

theme = {
  ...theme,
  overrides: {
    MuiDrawer: {
      paper: {
        backgroundColor: '#18202c',
      },
    },
    MuiButton: {
      label: {
        textTransform: 'none',
      },
      contained: {
        boxShadow: 'none',
        '&:active': {
          boxShadow: 'none',
        },
      },
    },
    MuiTabs: {
      root: {
        marginLeft: theme.spacing(1),
      },
      indicator: {
        height: 3,
        borderTopLeftRadius: 3,
        borderTopRightRadius: 3,
        backgroundColor: theme.palette.common.white,
      },
    },
    MuiTab: {
      root: {
        textTransform: 'none',
        margin: '0 16px',
        minWidth: 0,
        padding: 0,
        [theme.breakpoints.up('md')]: {
          padding: 0,
          minWidth: 0,
        },
      },
    },
    MuiIconButton: {
      root: {
        padding: theme.spacing(1),
      },
    },
    MuiTooltip: {
      tooltip: {
        borderRadius: 4,
      },
    },
    MuiDivider: {
      root: {
        backgroundColor: '#404854',
      },
    },
    MuiListItemText: {
      primary: {
        fontWeight: theme.typography.fontWeightMedium,
      },
    },
    MuiListItemIcon: {
      root: {
        color: 'inherit',
        marginRight: 0,
        '& svg': {
          fontSize: 20,
        },
      },
    },
    MuiAvatar: {
      root: {
        width: 32,
        height: 32,
      },
    },
  },
};

const drawerWidth = 256;

const styles = createStyles({
  root: {
    display: 'flex',
    minHeight: '100vh',
  },
  drawer: {
    [theme.breakpoints.up('sm')]: {
      width: drawerWidth,
      flexShrink: 0,
    },
  },
  app: {
    flex: 1,
    display: 'flex',
    flexDirection: 'column',
  },
  main: {
    flex: 1,
    padding: theme.spacing(6, 4),
    background: '#eaeff1',
  },
  footer: {
    padding: theme.spacing(2),
    background: '#eaeff1',
  },
});

export interface AppProps extends WithStyles<typeof styles> {}

function App(props: AppProps) {
  const { classes } = props;
  const [mobileOpen, setMobileOpen] = React.useState(false);

  const handleDrawerToggle = () => {
    setMobileOpen(!mobileOpen);
  };

  const [errorMessage, updateErrorMessage] = useState(null);

  return (
        <ThemeProvider theme={theme}>
        <div className={classes.root}>
            <CssBaseline />
            <BrowserRouter>
                <nav className={classes.drawer}>
                <Hidden smUp implementation="js">
                    <LeftNavigator
                        PaperProps={{ style: { width: drawerWidth } }}
                        variant="temporary"
                        open={mobileOpen}
                        onClose={handleDrawerToggle}
                    />
                </Hidden>
                <Hidden xsDown implementation="css">
                    <LeftNavigator PaperProps={{ style: { width: drawerWidth } }} />
                </Hidden>
                </nav>
                <div className={classes.app}>
                <Header onDrawerToggle={handleDrawerToggle} />
                <main className={classes.main}>                    
                    <div className="App">
                        <div className="container d-flex align-items-center flex-column">
                          <Suspense fallback={<Loading />}>
                              <Switch>
                                  <Route exact={true} path="/">
                                    <Calendar />
                                  </Route>
                              </Switch>
                            </Suspense>
                            <ErrorModal errorMessage={errorMessage} hideError={updateErrorMessage}/>
                        </div>
                    </div>
                </main>
                <footer className={classes.footer}>
                    <Copyright />
                </footer>
                </div>
            </BrowserRouter>
        </div>
        </ThemeProvider>
  );
}

export default withStyles(styles)(App);
